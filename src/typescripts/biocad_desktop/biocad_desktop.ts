interface biocad_desktop {
    getUniprotXmlDatabase(): string;
    sendPost(url: string, json: string): hostMsg;
}

interface hostMsg {
    result: boolean;
    data: string;
}

namespace desktop {

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

    function toastHtml(msg: string,
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
            "data-mdb-autohide": autohide.toString()
        }).display(`        
            <div class="toast-header toast-${level}">
                <i class="${toastIconsMD[level]}"></i>
                <strong class="me-auto">${title}</strong>
                <small>${subtitle}</small>
                <button type="button" class="btn-close" data-mdb-dismiss="toast" aria-label="Close">
                </button>
            </div>
            <div class="toast-body">${processHtmlMsg(msg)}</div>
        `);

        return box;
    }

    function processHtmlMsg(text: string): string {
        text = text.replace("<", "&lt;");
        text = Strings.lineTokens(text).join("<br />");

        return text;
    }
}