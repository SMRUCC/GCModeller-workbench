namespace GCModeller.Workbench {

    export class Symbol {

        public symbol;
        public scale;
        public colour;

        public constructor(alph_index, scale, alphabet) {
            this.symbol = alphabet.get_letter(alph_index);
            this.scale = scale;
            this.colour = alphabet.get_colour(alph_index);
        }

        public toString(): string {
            return this.symbol + " " + (Math.round(this.scale * 1000) / 10) + "%";
        }

        public static compareSymbol(sym1: Symbol, sym2: Symbol): number {
            if (sym1.scale < sym2.scale) {
                return -1;
            } else if (sym1.scale > sym2.scale) {
                return 1;
            } else {
                return 0;
            }
        }
    }
}