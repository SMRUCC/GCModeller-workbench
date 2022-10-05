namespace pages {

    export abstract class analysis_session extends Bootstrap {

        protected session_id: string;

        /**
         * the unique session id generator for the R# backend
        */
        protected generateSsid(contents: {}): string {
            const json: string = JSON.stringify(contents);
            const contentStr = `${desktop.now()}-${json}-${this.appName}`;
            const hash: string = md5(contentStr);

            return hash;
        }
    }
}