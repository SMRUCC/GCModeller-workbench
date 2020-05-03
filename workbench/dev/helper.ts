module workbench.helpers {

    // 保持对window对象的全局引用，如果不这么做的话，当JavaScript对象被
    // 垃圾回收的时候，window对象将会自动的关闭
    let windows: Electron.BrowserWindow[] = <any>{};

    export function renderAppMenu(template: Electron.MenuItemConstructorOptions[]): Electron.Menu {
        // replace all url as menu click
        const menu = Menu.buildFromTemplate(runRender(template));

        Menu.setApplicationMenu(menu);

        return menu;
    }

    function runRender(template: Electron.MenuItemConstructorOptions[]): Electron.MenuItemConstructorOptions[] {
        for (let item of template) {
            renderMenuTemplate(item);
        }

        return template;
    }

    function renderMenuTemplate(templ: Electron.MenuItemConstructorOptions): Electron.MenuItemConstructorOptions {
        if (!(templ.submenu instanceof Menu)) {
            templ.submenu
                .filter(sm => "click" in sm)
                .forEach(sm => {
                    var url: string = sm.click + "";

                    sm.click = function () {
                        require('electron').shell.openExternal(url);
                    };
                });
            templ.submenu
                .filter(sm => sm.label == "Quit")
                .forEach(sm => {
                    sm.click = function () {
                        app.quit();
                    }
                })
        }

        return templ;
    }

    export function getMainWindow() {
        if (mainView in windows) {
            return windows[mainView];
        } else {
            return null;
        }
    }

    export function createWindow(view: string, size: number[] = [800, 600], callback: Delegate.Action = null, lambda: boolean = false, debug = false): Delegate.Action {
        let invoke: Delegate.Action = function (): Delegate.Action {
            // 创建浏览器窗口。
            let win = new BrowserWindow({ width: size[0], height: size[1] })

            // 然后加载应用的 index.html。
            win.loadFile(view);

            if (debug) {
                // 打开开发者工具
                win.webContents.openDevTools();
            }

            // 当 window 被关闭，这个事件会被触发。
            win.on('closed', () => {
                // 取消引用 window 对象，如果你的应用支持多窗口的话，
                // 通常会把多个 window 对象存放在一个数组里面，
                // 与此同时，你应该删除相应的元素。
                windows[view] = null
            });

            if (callback) {
                callback();
            }

            return <Delegate.Action>function () {

            }
        }

        return lambda ? invoke : <any>invoke();
    }
}