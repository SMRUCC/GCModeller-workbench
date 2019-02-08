declare module helpers {
    function renderAppMenu(template: Electron.MenuItemConstructorOptions[]): Electron.Menu;
}
declare const app: Electron.App, BrowserWindow: typeof Electron.BrowserWindow, Menu: typeof Electron.Menu, Notification: typeof Electron.Notification;
declare var template: Electron.MenuItemConstructorOptions[];
declare let win: Electron.BrowserWindow;
declare let menu: Electron.Menu;
declare function createWindow(): void;
