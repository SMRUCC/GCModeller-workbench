module helpers {

    export function renderAppMenu(template: Electron.MenuItemConstructorOptions[]): Electron.Menu {

        // replace all url as menu click
        template.forEach(function (m) {
            if (!(m.submenu instanceof Menu)) {
                m.submenu
                    .filter(sm => "click" in sm)
                    .forEach(sm => {
                        var url: string = sm.click + "";

                        sm.click = function () {
                            require('electron').shell.openExternal(url);
                        };
                    });
                m.submenu
                    .filter(sm => sm.label == "Quit")
                    .forEach(sm => {
                        sm.click = function () {
                            app.quit();
                        }
                    })
            }
        });

        console.log(template);

        const menu = Menu.buildFromTemplate(template);
        Menu.setApplicationMenu(menu);

        return menu;
    }
}