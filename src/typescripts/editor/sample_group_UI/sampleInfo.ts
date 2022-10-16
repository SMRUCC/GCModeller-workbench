namespace biodeep {

    export interface IsampleInfo {

        /**
         * the unique id
        */
        ID: string;
        /**
         * the display title of the sample
        */
        sample_name: string;
        /**
         * the sample group name
        */
        sample_info: string;
        /**
         * injection order in LC-MS experiment, used for batch normalization only
        */
        injectionOrder: number;
        /**
         * the LC-MS experiment batch number
        */
        batch: number;
        sample_info1?: string;
        sample_info2?: string;
        color: string;
        color1?: string;
        color2?: string;

        shape: number;
        shape1?: number;
        shape2?: number;

        delete?: string;
    }

    export function ensureSampleInfoModel(data: string[] | IEnumerator<string> | IsampleInfo[]): IsampleInfo[] {
        let type = $ts.typeof(data);

        if (type.isArrayOf("string") || type.isEnumerator) {
            let strings: string[]

            if (Array.isArray(data)) {
                strings = <string[]>data;
            } else {
                strings = (<IEnumerator<string>>data).ToArray(false);
            }

            let groupInfo: NamedValue<string[]>[];

            try {
                groupInfo = biodeep.guess_groupInfo(strings);
            } catch {
                groupInfo = [new NamedValue<string[]>("unknown", strings)];
            }

            return biodeep.buildModels(groupInfo);
        } else {
            let copy = <IsampleInfo[]>data;

            for (let item of copy) {
                if (Strings.Empty(item.sample_info1, true)) {
                    item.sample_info1 = "";
                }
                if (Strings.Empty(item.sample_info2, true)) {
                    item.sample_info2 = "";
                }
            }

            return copy;
        }
    }

    export function as_tabular(sampleInfo: IsampleInfo[] | IEnumerator<IsampleInfo>): string {
        return $ts.csv.toText(sampleInfo, false);
    }

    export function buildModels(guessInfo: NamedValue<string[]>[]): IsampleInfo[] {
        let data: IsampleInfo[] = [];

        for (let group of guessInfo) {
            for (let label of group.value) {
                data.push(<IsampleInfo>{
                    ID: label,
                    sample_name: label,
                    sample_info: group.name,
                    injectionOrder: 0,
                    batch: 1,
                    color: "000000",
                    shape: 19,
                    sample_info1: "",
                    sample_info2: ""
                });
            }
        }

        return data;
    }

    export function guess_groupInfo(sampleNames: string[] | IEnumerator<string>): NamedValue<string[]>[] {
        if (!Array.isArray(sampleNames)) {
            sampleNames = (<IEnumerator<string>>sampleNames).ToArray();
        }

        let common: string[] = [];
        let column: string[];
        let unique: string[];
        let matrix: string[][] = $from(sampleNames).Select(s => <string[]>Strings.ToCharArray(s, false)).ToArray(false);
        let minLen: number = $from(matrix).Min(s => s.length).length;
        let groups: NamedValue<string[]>[] = [];

        for (let i = 0; i < minLen; i++) {
            column = [];

            for (let name of matrix) {
                column.push(name[i]);
            }

            unique = $from(column).Distinct().ToArray(false);

            if (unique.length == 1) {
                common.push(unique[0]);
            } else {
                for (let start of unique) {
                    let index = $from(column).Select(c => c == start).ToArray(false);
                    let part = $from(matrix).subset(index);
                    let sampleGroup = splitOfGroupLabels([...common], i, part.ToArray(false));

                    groups.push(sampleGroup);
                }

                break;
            }
        }

        return groups;
    }

    /**
     * move to next untile get next different character 
    */
    function splitOfGroupLabels(common: string[], i: number, matrix: string[][]): NamedValue<string[]> {
        let minLen: number = $from(matrix).Min(s => s.length).length;
        let column: string[];
        let unique: string[];
        let labels = $from(matrix).Select(s => s.join("")).ToArray(false);

        for (; i < minLen; i++) {
            column = [];

            for (let name of matrix) {
                column.push(name[i]);
            }

            unique = $from(column).Distinct().ToArray(false);

            if (unique.length == 1) {
                common.push(unique[0]);
            } else {
                let groupLabel: string = Strings.RTrim(common.join(""), "-_.+&$#@!`~ ");
                let info = new NamedValue<string[]>(groupLabel, labels);

                return info;
            }
        }
    }
}

