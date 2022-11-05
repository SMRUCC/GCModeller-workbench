namespace pages {

    export interface webapp {
        title: string;
        desc: string;
        /**
         * The function name to invoke method in host app
         * 
         * this property can be used as the unique id of the web app
        */
        appLink: string;
        icon: string;
    }

    export function toSearchTerm(item: webapp, i: number): pages.suggestion_list.term[] {
        const list: pages.suggestion_list.term[] = [];

        list.push(new pages.suggestion_list.term(i, item.title));
        list.push(new pages.suggestion_list.term(i, item.appLink));
        list.push(new pages.suggestion_list.term(i, item.desc));

        return list;
    }

    export class applets extends Bootstrap {

        static readonly defaultIcon: string = "/assets/images/background.jpg";
        readonly appList: webapp[] = [
            <webapp>{ appLink: "apps.gcmodeller.openZscore", title: "Z-score analysis", desc: "Z-score analysis", icon: applets.defaultIcon },
            <webapp>{ appLink: "apps.gcmodeller.openDataEmbedding", title: "Data Embedding", desc: "PCA/UMAP/t-SNE data embedding", icon: applets.defaultIcon },
            <webapp>{ appLink: "apps.gcmodeller.openCMeans", title: "Fuzzy CMeans", desc: "Fuzzy cmeans clustering", icon: applets.defaultIcon },
            <webapp>{ appLink: "apps.gcmodeller.openPLAS", title: "PLAS", desc: "bio-chemical system simulator", icon: applets.defaultIcon },
            <webapp>{ appLink: "apps.gcmodeller.openMotifViewer", title: "Motif logo", desc: "View motif matrix in web logo rendering", icon: applets.defaultIcon }
        ];

        private terms: pages.suggestion_list.term[] = [];
        private suggestions: pages.suggestion_list.suggestion;

        public get appName(): string {
            return "applets";
        };

        protected init(): void {
            // throw new Error("Method not implemented.");
            pages.background.run();
            applets.showAppList(this.appList);

            for (let i: number = 0; i < this.appList.length; i++) {
                for (let item of toSearchTerm(this.appList[i], i)) {
                    this.terms.push(item);
                }
            }

            this.suggestions = new pages.suggestion_list.suggestion(this.terms);
            this.hookSearchBar();
        }

        /**
         * handling of the app search event
        */
        private hookSearchBar() {
            const node = $ts("#applets");
            const vm = this;
            const top: number = 6;
            const caseInsensitive: boolean = false;
            const click = function (term: pages.suggestion_list.term) {
                const app = vm.appList[term.id];
                const appLink = app.appLink;

                eval(`${appLink}();`);
            }
            const searchBar: HTMLInputElement = <any>$ts("#form1");
            const search = (input: string) => {
                node.clear();

                for (let term of vm.suggestions.populateSuggestion(input, top, caseInsensitive)) {
                    const applink = applets.buildElement(vm.appList[term.id]);
                    node.appendChild(applink);
                }
            };

            searchBar.onchange = function () {
                if ((!searchBar.value) || (searchBar.value == "")) {
                    // reset
                    applets.showAppList(vm.appList);
                } else {
                    search(searchBar.value);
                }
            }
        }

        private static showAppList(appList: webapp[]) {
            const applets: HTMLElement = $ts("#applets").clear();

            for (let app of appList) {
                applets.appendChild(pages.applets.buildElement(app));
            }
        }

        private static buildElement(app: webapp): HTMLElement {
            return $ts("<div>", { class: ["col-xl-4", "col-lg-6", "mb-4"] })
                .display(`     
<a href="#" onclick="${app.appLink}();" class="card ripple bg-image hover-zoom">
    <div class="card-body">
        <div class="d-flex align-items-center">
            <img src="${app.icon}" alt="" class="img-fluid rounded icon-image" />
            <div class="ms-3">
                <p class="fw-bold mb-1">${app.title}</p>
                <p class="text-muted mb-0">${app.desc}</p>
            </div>
        </div>
    </div>
</a>
`);
        }
    }
}