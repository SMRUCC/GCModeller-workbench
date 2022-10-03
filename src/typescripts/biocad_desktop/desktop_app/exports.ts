
namespace desktop {

    export async function parseResultFlag(msg: hostMsg, message: IMsg<string>) {
        const flag = await msg.result;
        const result = flag && (message.code == 0);

        return result;
    }

    export async function parseMessage(msg: hostMsg) {
        const dataString = await msg.data;
        const json = <IMsg<string>>JSON.parse(dataString);

        return json;
    }

    export function showToastMessage(msg: string,
        title: string = "Task Error",
        subtitle: string = "",
        level: "danger" | "success" | "warning" | "info" = "info",
        autohide: boolean = true) {

        $ts("#toast-message").appendElement(toastHtml(msg, title, subtitle, level, autohide));
    }

    const toastIconsMD = {
        "success": "fas fa-check fa-lg me-2",
        "danger": "fas fa-exclamation-circle fa-lg me-2",
        "warning": "fas fa-exclamation-triangle fa-lg me-2",
        "info": "fas fa-info-circle fa-lg me-2"
    }

    function toastHtml(msg: string | Object,
        title: string = "Task Error",
        subtitle: string = "",
        level: string = "danger",
        autohide: boolean = true): HTMLElement {

        const box = $ts("<div>", <any>{
            class: ["toast", "show", "fade", `toast-${level}`],
            role: "alert",
            "aria-live": "assertive",
            "aria-atomic": "true",
            "data-mdb-color": level,
            "data-mdb-autohide": autohide.toString(),
            style: "width: 500px;"
        }).display(`        
            <div class="toast-header toast-${level}">
                <i class="${toastIconsMD[level]}"></i>
                <strong class="me-auto">${title}</strong>
                <small>${(!subtitle) || (subtitle.toLowerCase() == "null") ? "" : subtitle}</small>
                <button type="button" class="btn-close" data-mdb-dismiss="toast" aria-label="Close">
                </button>
            </div>
            <div class="toast-body">${processHtmlMsg(msg)}</div>
        `);

        return box;
    }

    function processHtmlMsg(text: string | Object): string {
        if (typeof text == "string") {
            text = text.replace(/[<]/ig, "&lt;");
            text = Strings.lineTokens(<string>text).join("<br />");
        } else if (RSharp.isRSharpError(<any>text)) {
            text = RSharp.RSharpErrorMessage(<any>text);
        } else {
            text = "Unhandle error!";
        }

        return <string>text;
    }
}