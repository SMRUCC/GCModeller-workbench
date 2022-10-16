namespace biodeep {

    export class labelStack {

        private labels: string[] = [];

        public get n(): number {
            return this.labels.length;
        }

        public add(label: string) {
            this.labels.push(label);
        }

        public delete(label: string) {
            this.labels = $from(this.labels).Where(a => a != label).ToArray(false);
        }

        public popall(): string[] {
            let pop = [...this.labels];
            this.labels = [];
            return pop;
        }
    }
}