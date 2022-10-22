namespace omicsAnalysis {  

    export function parseSampleInfo(analysis_file: string, using: Delegate.Sub, err: Delegate.Sub = null): void {
        $ts.get(sampleInfoUrl + analysis_file, function (result: IMsg<string>) {
            if (result.code != 0) {
                if (isNullOrUndefined(err)) {
                    desktop.showToastMessage(result.info, "Parse SampleInfo", "danger");
                } else {
                    err(result.info);
                }
            } else {
                let samples = $ts.csv
                    .toObjects<sampleinfo_editor.IsampleInfo>(result.info)
                    .ToArray(false);

                // debug echo
                TypeScript.logging.table(samples);
                // do things with sampleinfo data.
                using(samples);
            }
        });
    }

    export function saveSampleInfo(table: sampleinfo_editor.IsampleInfo[], analysis_file: string, success: Delegate.Action) {
        let csv = {
            csv: $ts.csv.toText(table)
        };
        let url: string = `@api:save?file=${analysis_file}&category=sampleInfo`;

        TypeScript.logging.table(table);
        TypeScript.logging.log(url, TypeScript.ConsoleColors.DarkRed);

        $ts.post(url, csv, function (result) {
            desktop.closeSpinner();

            if (result.code != 0) {
                desktop.showToastMessage(<string>result.info, "Save SampleInfo", "danger");
            } else {
                desktop.showToastMessage(<string>result.info, "Save SampleInfo", "success");
                success();
            }
        });
    }
}