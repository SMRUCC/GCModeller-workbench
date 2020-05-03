/// <reference path="node_modules/electron/electron.d.ts" />
declare module workbench.helpers {
    function renderAppMenu(template: Electron.MenuItemConstructorOptions[]): Electron.Menu;
    function getMainWindow(): any;
    function createWindow(view: string, size?: number[], callback?: Delegate.Action, lambda?: boolean, debug?: boolean): Delegate.Action;
}
declare module workbench.Shell {
    function Rweb(): any;
}
declare const app: Electron.App, BrowserWindow: typeof Electron.BrowserWindow, Menu: typeof Electron.Menu, Notification: typeof Electron.Notification;
declare const mainView: string;
declare const backend: any;
declare let template: Electron.MenuItemConstructorOptions[];
declare let menu: Electron.Menu;
