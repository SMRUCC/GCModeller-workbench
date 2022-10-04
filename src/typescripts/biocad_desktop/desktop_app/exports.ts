
namespace desktop {

    export async function parseResultFlag(msg: hostMsg, message: IMsg<string>) {
        const flag = await msg.result;
        const result = flag && (message.code == 0);

        return result;
    }

    export async function parseMessage(msg: hostMsg) {
        let dataString = await msg.data;
        let json: IMsg<string>

        if ($ts.csv.isTsvFile(dataString)) {
            json = <IMsg<string>>{
                code: 0,
                info: dataString
            }
        } else if (dataString.startsWith("data:")) {
            // is a dataURI string
            json = <IMsg<string>>{
                code: 0,
                info: dataString
            }
        } else {
            try {
                json = <IMsg<string>>JSON.parse(dataString);
            } catch {
                json = <IMsg<string>>{
                    code: 500,
                    info: dataString
                };
            }
        }

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