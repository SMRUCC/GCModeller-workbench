namespace pages {

    export abstract class analysis_session extends Bootstrap {

        protected session_id: string;

        /**
         * the unique session id generator for the R# backend
         * 
         * this unique id is generated based on the context of:
         * 
         *   1. current timestamp
         *   2. current page app name
         *   3. additionally, the analysis parameter json object string
         * 
         * @param contents the additional context data to generate 
         *    the guid, this parameter value can be optional
        */
        protected generateSsid(contents = {}): string {
            const vm = this;
            const json: string = JSON.stringify(contents);
            const contentStr = `${desktop.now()}-${json}-${vm.appName}`;
            const hash: string = md5(contentStr);

            return hash;
        }
    }
}