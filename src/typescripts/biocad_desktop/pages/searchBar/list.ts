namespace pages.suggestion_list {

    export class suggestion {

        constructor(private terms: term[]) {
        }

        public hasEquals(input: string, caseInsensitive: boolean = false): boolean {
            if (!caseInsensitive) {
                input = input.toLowerCase();
            }

            for (let term of this.terms) {
                if (caseInsensitive) {
                    if (term.term.toLowerCase() == input) {
                        return true;
                    }
                } else {
                    if (term.term == input) {
                        return true;
                    }
                }
            }

            return false;
        }

        /**
         * 返回最相似的前5个结果
        */
        public populateSuggestion(input: string,
            top: number = 5,
            caseInsensitive: boolean = false): term[] {

            var lowerInput: string = input.toLowerCase();
            var scores: IEnumerator<scoreTerm> = $from(this.terms)
                .Select(q => {
                    var score: number = suggestion.getScore(
                        q, input,
                        lowerInput,
                        caseInsensitive
                    );
                    return <scoreTerm>{
                        term: q, score: score
                    };
                })
                .OrderBy(rank => rank.score);
            var result: term[] = scores
                .Where(s => s.score != NA)
                .Take(top)
                .Select(s => s.term)
                .ToArray();

            if (result.length == top) {
                return result;
            } else {
                return suggestion.makeAdditionalSuggestion(scores, result, caseInsensitive, input, top);
            }
        }

        // 非NA得分的少于top的数量
        // 需要换一种方式计算结果，然后进行补充
        private static makeAdditionalSuggestion(
            scores: IEnumerator<scoreTerm>,
            result: term[],
            caseInsensitive: boolean,
            input: string,
            top: number) {

            let lowerInput: string = input.toLowerCase();
            let addi: term[] = scores
                .Skip(result.length)
                .Select(s => {
                    var q: term = s.term;
                    var score: number;

                    if (caseInsensitive) {
                        score = Levenshtein.ComputeDistance(q.term.toLowerCase(), lowerInput);
                    } else {
                        score = Levenshtein.ComputeDistance(q.term, input);
                    }

                    return <scoreTerm>{
                        term: q, score: score
                    };
                }).OrderBy(s => s.score)
                .Take(top - result.length)
                .Select(s => s.term)
                .ToArray();

            return [...result, ...addi];
        }

        private static getScore(q: term,
            input: string,
            lowerInput: string,
            caseInsensitive: boolean): number {

            if (caseInsensitive) {
                // 大小写不敏感的模式下，都转换为小写
                var lowerTerm: string = q.term.toLowerCase();

                return term.indexOf(
                    lowerTerm,
                    lowerInput
                );

            } else {
                return q.dist(input);
            }
        }
    }
}