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

    export class applets extends Bootstrap {

        static readonly defaultIcon: string = "/assets/images/background.jpg";
        readonly appList: webapp[] = [
            <webapp>{ appLink: "apps.gcmodeller.openZscore", title: "Z-score analysis", desc: "Z-score analysis", icon: applets.defaultIcon },
            <webapp>{ appLink: "apps.gcmodeller.openDataEmbedding", title: "Data Embedding", desc: "PCA/UMAP/t-SNE data embedding", icon: applets.defaultIcon },
            <webapp>{ appLink: "apps.gcmodeller.openCMeans", title: "Fuzzy CMeans", desc: "Fuzzy cmeans clustering", icon: applets.defaultIcon },
            <webapp>{ appLink: "apps.gcmodeller.openPLAS", title: "PLAS", desc: "bio-chemical system simulator", icon: applets.defaultIcon }
        ];

        public get appName(): string {
            return "applets";
        };

        protected init(): void {
            // throw new Error("Method not implemented.");
            pages.background.run();
            applets.showAppList(this.appList);
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