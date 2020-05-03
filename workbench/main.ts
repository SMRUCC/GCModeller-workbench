/// <reference path="node_modules/electron/electron.d.ts" />
/// <reference path="dev/helper.ts" />
//// <reference path="vendor/linq.d.ts" />

// load framework
const { app, BrowserWindow, Menu, Notification } = require('electron');
const { $from } = require("./vendor/linq.js");

const mainView: string = "./views/index.html";

// load internal app components
let template: Electron.MenuItemConstructorOptions[] = require("./menu.json");
let menu: Electron.Menu = null;

// Electron 会在初始化后并准备
// 创建浏览器窗口时，调用这个函数。
// 部分 API 在 ready 事件触发后才能使用。
app.on('ready', workbench.helpers.createWindow(mainView, [800, 600], function () {
    menu = workbench.helpers.renderAppMenu(template);

    var msg: Electron.Notification = new Notification({ title: "Task Finish", body: "test task finished!" });
    msg.show();
}, true));

// 当全部窗口关闭时退出。
app.on('window-all-closed', function() {
    // 在 macOS 上，除非用户用 Cmd + Q 确定地退出，
    // 否则绝大部分应用及其菜单栏会保持激活。
    if (process.platform !== 'darwin') {
        app.quit()
    }
});

app.on('activate', function () {
    // 在macOS上，当单击dock图标并且没有其他窗口打开时，
    // 通常在应用程序中重新创建一个窗口。
    if (workbench.helpers.getMainWindow() === null) {
        workbench.helpers.createWindow(mainView);
    }
})

// 在这个文件中，你可以续写应用剩下主进程代码。
// 也可以拆分成几个文件，然后用 require 导入。