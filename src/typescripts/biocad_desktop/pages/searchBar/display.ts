namespace pages.suggestion_list.render {

    /**
     * 将结果显示到网页上面
     * 
     * @param div 带有#符号前缀的id查询表达式
    */
    export function makeSuggestions(terms: term[], div: string,
        click: (term: term) => void,
        top: number = 10,
        caseInsensitive: boolean = false,
        divClass = null,
        addNew: ((newTerm: string) => void) = null): (input: string) => void {

        var suggestions: suggestion = new suggestion(terms);

        return (input: string) => {
            showSuggestions(suggestions, input,
                div, click,
                top, caseInsensitive, addNew,
                divClass
            );
        };
    }

    function showSuggestions(suggestion: suggestion,
        input: string,
        div: string,
        click: (term: term) => void,
        top: number = 10,
        caseInsensitive: boolean = false,
        addNew: (newTerm: string) => void = null,
        divClass = null) {

        var node = $ts(div);

        if (!node) {
            return;
        } else {
            node.clear();
        }

        suggestion.populateSuggestion(input, top, caseInsensitive)
            .forEach(term => {
                node.appendChild(listItem(term, divClass, click));
            });

        if ((!isNullOrUndefined(addNew)) && (!suggestion.hasEquals(input, caseInsensitive))) {
            let addNewButton = $ts("<a>", {
                href: executeJavaScript,
                text: input,
                title: input,
                onclick: function () {
                    addNew(input);
                }
            }).display(`add '${input}'`);

            node.append($ts("<div>", {
                class: divClass
            }).display(addNewButton));
        }
    }

    function listItem(term: term, divClass: string, click: (term: term) => void): HTMLElement {
        let a = $ts("<a>", {
            href: executeJavaScript,
            text: term.term,
            title: term.term,
            onclick: function () {
                click(term);
            }
        }).display(term.term);

        return $ts("<div>", { class: divClass }).display(a);
    }
}