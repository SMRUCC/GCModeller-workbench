namespace GCModeller.Workbench {

    export class Alphabet {

        public static readonly is_letter: RegExp = /^\w$/;
        public static readonly is_prob: RegExp = /^((1(\.0+)?)|(0(\.\d+)?))$/;

        public freqs: number[] = [];
        public alphabet: string[] = [];
        public letter_count: number = 0;

        public constructor(alphabet: string, bg: string) {
            var letter: string;

            for (var pos: number = 0; pos < alphabet.length; pos++) {
                letter = alphabet.charAt(pos);

                if (Alphabet.is_letter.test(letter)) {
                    this.alphabet[this.letter_count] = letter.toUpperCase();
                    this.freqs[this.letter_count] = -1;
                    this.letter_count++;
                }
            }

            if (typeof bg !== "undefined") {
                this.parseBackground(bg.split(/\s+/));
            } else {
                var freq: number;

                // assume uniform background
                freq = 1.0 / this.letter_count;

                for (pos = 0; pos < this.letter_count; pos++) {
                    this.freqs[pos] = freq;
                }
            }
        }

        private parseBackground(parts: string[]): void {
            var parts: string[];
            var letter: string;
            var freq: string;

            for (var i: number = 0, pos = 0; (i + 1) < parts.length; i += 2) {
                letter = parts[i];
                freq = parts[i + 1];

                if (Alphabet.is_letter.test(letter) && Alphabet.is_prob.test(freq)) {
                    // find the letter it matches
                    letter = letter.toUpperCase();

                    for (; pos < this.letter_count; pos++) {
                        if (this.alphabet[pos] == letter) {
                            break;
                        }
                    }
                    if (pos >= this.letter_count) {
                        throw new Error("NOT_IN_ALPHABET");
                    }
                    this.freqs[pos] = parseFloat(freq);
                }
            }
        }
    }
}