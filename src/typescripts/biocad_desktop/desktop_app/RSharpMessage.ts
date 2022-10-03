namespace desktop {

    export interface RSharpError {
        Message: string | string[];
        Source: string;
        TypeFullName: string;
        StackTrace: {
            File: string;
            Line: string;
            Method: {
                Method: string;
                Module: string;
                Namespace: string;
            }
        }[];
    }
}

namespace desktop.RSharp {

    export function RSharpErrorMessage(obj: RSharpError): string {
        let sb = "R# Error:";
        let i = 1;
        let method: string;

        if (typeof obj.Message == "string") {
            sb = sb + "&nbsp;" + obj.Message.replace(/[<]/ig, "&lt;");
        } else {
            sb = sb + "<br/><br/>";

            for (let line of obj.Message) {
                sb = sb + `&nbsp;&nbsp;${i++}.${line.replace(/[<]/ig, "&lt;")}<br/>`;
            }
        }

        sb = sb + "<br/>";
        sb = sb + `&nbsp;&nbsp;&nbsp;${obj.Source.replace(/[<]/ig, "&lt;")}<br/>`;
        sb = sb + `&nbsp;&nbsp;&nbsp;${"~".repeat(obj.Source.length)}<br/>`;
        sb = sb + "<br/>";

        for (let frame of obj.StackTrace) {
            method = `${frame.Method.Namespace}.${frame.Method.Module}.${frame.Method.Method}`;
            method = `${method} at ${frame.File} line ${frame.Line}`;
            sb = sb + `${method.replace(/[<]/ig, "&lt;")}<br />`;
        }

        return sb;
    }

    export function isRSharpError(obj: {}): boolean {
        const type = TypeScript.Reflection.$typeof(obj);
        const checks = ["Message", "Source", "TypeFullName", "StackTrace"];

        return $ts(checks).All(name => type.property.indexOf(name) > -1);
    }
}