
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

    export function processHtmlMsg(text: string | Object): string {
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