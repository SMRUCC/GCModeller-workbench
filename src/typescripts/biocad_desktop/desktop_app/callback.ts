namespace desktop {

    export interface messageCallback<T> { (success: boolean, message: IMsg<T>): void };

    /**
     * the host message async callback helper
    */
    export async function promiseAsyncCallback<T>(hostMsg: hostMsg, callback: messageCallback<T>) {
        desktop.parseMessage(hostMsg).then(function (message) {
            desktop.parseResultFlag(hostMsg, message).then(function (flag) {
                callback(flag, <any>message);
            });
        });
    }

    /**
     * show ``#busy-indicator`` loading spinner
    */
    export function loading(message: string = "Loading...") {
        $ts("#spinner-message").display(message);
        $ts("#busy-indicator").show();
    }

    export function closeSpinner() {
        $ts("#busy-indicator").hide();
    }
}