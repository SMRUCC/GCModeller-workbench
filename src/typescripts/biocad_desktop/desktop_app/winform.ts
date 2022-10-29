namespace desktop.winforms {

    export function openfileDialog(textbox_id: string, filter: string = "any file(*.*)|*.*") {
        desktop.loading();
        apps.gcmodeller
            .getFileOpen(filter)
            .then(async function (path) {
                const file: string = await path;
                const textbox: HTMLInputElement = <any>$ts(textbox_id);

                textbox.value = file;
                desktop.closeSpinner();
            });
    }
}