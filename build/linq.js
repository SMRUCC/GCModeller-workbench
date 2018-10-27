var GCModeller;
(function (GCModeller) {
    var Workbench;
    (function (Workbench) {
        var Alphabet = /** @class */ (function () {
            function Alphabet(alphabet, bg) {
                this.freqs = [];
                this.alphabet = [];
                this.letter_count = 0;
                var letter;
                for (var pos = 0; pos < alphabet.length; pos++) {
                    letter = alphabet.charAt(pos);
                    if (Alphabet.is_letter.test(letter)) {
                        this.alphabet[this.letter_count] = letter.toUpperCase();
                        this.freqs[this.letter_count] = -1;
                        this.letter_count++;
                    }
                }
                if (typeof bg !== "undefined") {
                    this.parseBackground(bg.split(/\s+/));
                }
                else {
                    var freq;
                    // assume uniform background
                    freq = 1.0 / this.letter_count;
                    for (pos = 0; pos < this.letter_count; pos++) {
                        this.freqs[pos] = freq;
                    }
                }
            }
            Object.defineProperty(Alphabet.prototype, "ic", {
                get: function () {
                    if (this.isNucleotide) {
                        return 2;
                    }
                    else {
                        return Math.log(20) / Math.LN2;
                    }
                },
                enumerable: true,
                configurable: true
            });
            Object.defineProperty(Alphabet.prototype, "size", {
                get: function () {
                    return this.letter_count;
                },
                enumerable: true,
                configurable: true
            });
            Object.defineProperty(Alphabet.prototype, "isNucleotide", {
                get: function () {
                    //TODO basic method, make better
                    if (this.letter_count < 20) {
                        return true;
                    }
                    return false;
                },
                enumerable: true,
                configurable: true
            });
            Alphabet.prototype.parseBackground = function (parts) {
                var parts;
                var letter;
                var freq;
                for (var i = 0, pos = 0; (i + 1) < parts.length; i += 2) {
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
            };
            Alphabet.prototype.toString = function () {
                return (this.isNucleotide ? "Nucleotide" : "Protein") + " Alphabet " + (this.alphabet.join(""));
            };
            Alphabet.prototype.getLetter = function (index) {
                if (index < 0 || index >= this.letter_count) {
                    throw new Error("BAD_ALPHABET_INDEX");
                }
                return this.alphabet[index];
            };
            Alphabet.prototype.getBgfreq = function (index) {
                if (index < 0 || index >= this.letter_count) {
                    throw new Error("BAD_ALPHABET_INDEX");
                }
                if (this.freqs[index] == -1) {
                    throw new Error("BG_FREQ_NOT_SET");
                }
                return this.freqs[index];
            };
            Alphabet.prototype.getColour = function (index) {
                if (index < 0 || index >= this.letter_count) {
                    throw new Error("BAD_ALPHABET_INDEX");
                }
                if (this.isNucleotide) {
                    return Workbench.AlphabetColors.nucleotideColor(this.alphabet[index]);
                }
                else {
                    return Workbench.AlphabetColors.proteinColor(this.alphabet[index]);
                }
                return "black";
            };
            Alphabet.prototype.isAmbig = function (index) {
                if (index < 0 || index >= this.letter_count) {
                    throw new Error("BAD_ALPHABET_INDEX");
                }
                if (this.isNucleotide) {
                    return ("ACGT".indexOf(this.alphabet[index]) == -1);
                }
                else {
                    return ("ACDEFGHIKLMNPQRSTVWY".indexOf(this.alphabet[index]) == -1);
                }
            };
            Alphabet.prototype.getIndex = function (letter) {
                for (var i = 0; i < this.letter_count; i++) {
                    if (this.alphabet[i] == letter.toUpperCase()) {
                        return i;
                    }
                }
                throw new Error("UNKNOWN_LETTER");
            };
            Alphabet.is_letter = /^\w$/;
            Alphabet.is_prob = /^((1(\.0+)?)|(0(\.\d+)?))$/;
            return Alphabet;
        }());
        Workbench.Alphabet = Alphabet;
    })(Workbench = GCModeller.Workbench || (GCModeller.Workbench = {}));
})(GCModeller || (GCModeller = {}));
var GCModeller;
(function (GCModeller) {
    var Workbench;
    (function (Workbench) {
        var AlphabetColors;
        (function (AlphabetColors) {
            AlphabetColors.red = "rgb(204,0,0)";
            AlphabetColors.blue = "rgb(0,0,204)";
            AlphabetColors.orange = "rgb(255,179,0)";
            AlphabetColors.green = "rgb(0,128,0)";
            AlphabetColors.yellow = "rgb(255,255,0)";
            AlphabetColors.purple = "rgb(204,0,204)";
            AlphabetColors.magenta = "rgb(255,0,255)";
            AlphabetColors.pink = "rgb(255,204,204)";
            AlphabetColors.turquoise = "rgb(51,230,204)";
            function nucleotideColor(alphabet) {
                switch (alphabet) {
                    case "A":
                        return AlphabetColors.red;
                    case "C":
                        return AlphabetColors.blue;
                    case "G":
                        return AlphabetColors.orange;
                    case "T":
                        return AlphabetColors.green;
                    default:
                        throw new Error("Invalid nucleotide letter");
                }
            }
            AlphabetColors.nucleotideColor = nucleotideColor;
            function proteinColor(alphabet) {
                switch (alphabet) {
                    case "A":
                    case "C":
                    case "F":
                    case "I":
                    case "L":
                    case "V":
                    case "W":
                    case "M":
                        return AlphabetColors.blue;
                    case "N":
                    case "Q":
                    case "S":
                    case "T":
                        return AlphabetColors.green;
                    case "D":
                    case "E":
                        return AlphabetColors.magenta;
                    case "K":
                    case "R":
                        return AlphabetColors.red;
                    case "H":
                        return AlphabetColors.pink;
                    case "G":
                        return AlphabetColors.orange;
                    case "P":
                        return AlphabetColors.yellow;
                    case "Y":
                        return AlphabetColors.turquoise;
                    default:
                        throw new Error("Invalid protein letter");
                }
            }
            AlphabetColors.proteinColor = proteinColor;
        })(AlphabetColors = Workbench.AlphabetColors || (Workbench.AlphabetColors = {}));
    })(Workbench = GCModeller.Workbench || (GCModeller.Workbench = {}));
})(GCModeller || (GCModeller = {}));
var GCModeller;
(function (GCModeller) {
    var Workbench;
    (function (Workbench) {
        var Logo = /** @class */ (function () {
            function Logo(alphabet, fine_text) {
                this.rows = 0;
                this.columns = 0;
                this.alphabet = alphabet;
                this.fine_text = fine_text;
                this.pspm_list = [];
                this.pspm_column = [];
            }
            Logo.prototype.addPspm = function (pspm, column) {
                var col;
                if (typeof column === "undefined") {
                    column = 0;
                }
                else if (column < 0) {
                    throw new Error("Column index out of bounds.");
                }
                this.pspm_list[this.rows] = pspm;
                this.pspm_column[this.rows] = column;
                this.rows++;
                col = column + pspm.get_motif_length();
                if (col > this.columns) {
                    this.columns = col;
                }
            };
            Logo.prototype.getPspm = function (rowIndex) {
                if (rowIndex < 0 || rowIndex >= this.rows) {
                    throw new Error("INDEX_OUT_OF_BOUNDS");
                }
                return this.pspm_list[rowIndex];
            };
            Logo.prototype.getOffset = function (rowIndex) {
                if (rowIndex < 0 || rowIndex >= this.rows) {
                    throw new Error("INDEX_OUT_OF_BOUNDS");
                }
                return this.pspm_column[rowIndex];
            };
            ;
            return Logo;
        }());
        Workbench.Logo = Logo;
    })(Workbench = GCModeller.Workbench || (GCModeller.Workbench = {}));
})(GCModeller || (GCModeller = {}));
var GCModeller;
(function (GCModeller) {
    var Workbench;
    (function (Workbench) {
        var LogoMetrics = /** @class */ (function () {
            function LogoMetrics(ctx, logo_columns, logo_rows, allow_space_for_names) {
                this.pad_top = 5;
                this.pad_left = 10;
                this.pad_right = 5;
                this.pad_bottom = 0;
                this.pad_middle = 20;
                this.name_height = 14;
                this.name_spacer = 0;
                this.y_label_height = 12;
                this.y_label_spacer = 3;
                this.y_num_height = 12;
                this.y_num_width = 0;
                this.y_tic_width = 5;
                this.stack_pad_left = 0;
                this.stack_font = "bold 25px Helvetica, sans-serif";
                this.stack_height = 90;
                this.stack_width = 26;
                this.stacks_pad_right = 5;
                this.x_num_above = 2;
                this.x_num_height = 12;
                this.x_num_width = 0;
                this.fine_txt_height = 6;
                this.fine_txt_above = 2;
                this.letter_metrics = [];
                this.summed_width = 0;
                this.summed_height = 0;
                var i, row_height;
                if (typeof allow_space_for_names === "undefined") {
                    allow_space_for_names = false;
                }
                this.name_font = "bold " + this.name_height + "px Times, sans-serif";
                this.y_label = "bits";
                this.y_label_font = "bold " + this.y_label_height + "px Helvetica, sans-serif";
                this.y_num_font = "bold " + this.y_num_height + "px Helvetica, sans-serif";
                this.stack_font = "bold 25px Helvetica, sans-serif";
                this.x_num_font = "bold " + this.x_num_height + "px Helvetica, sans-serif";
                this.fine_txt_font = "normal " + this.fine_txt_height + "px Helvetica, sans-serif";
                //calculate the width of the y axis numbers
                ctx.font = this.y_num_font;
                for (i = 0; i <= 2; i++) {
                    this.y_num_width = Math.max(this.y_num_width, ctx.measureText("" + i).width);
                }
                //calculate the width of the x axis numbers (but they are rotated so it becomes height)
                ctx.font = this.x_num_font;
                for (i = 1; i <= logo_columns; i++) {
                    this.x_num_width = Math.max(this.x_num_width, ctx.measureText("" + i).width);
                }
                //calculate how much vertical space we want to draw this
                //first we add the padding at the top and bottom since that's always there
                this.summed_height += this.pad_top + this.pad_bottom;
                //all except the last row have the same amount of space allocated to them
                if (logo_rows > 1) {
                    row_height = this.stack_height + this.pad_middle;
                    if (allow_space_for_names) {
                        row_height += this.name_height;
                        //the label is allowed to overlap into the spacer
                        row_height += Math.max(this.y_num_height / 2, this.name_spacer);
                        //the label is allowed to overlap the space used by the other label
                        row_height += Math.max(this.y_num_height / 2, this.x_num_height + this.x_num_above);
                    }
                    else {
                        row_height += this.y_num_height / 2;
                        //the label is allowed to overlap the space used by the other label
                        row_height += Math.max(this.y_num_height / 2, this.x_num_height + this.x_num_above);
                    }
                    this.summed_height += row_height * (logo_rows - 1);
                }
                //the last row has the name and fine text below it but no padding
                this.summed_height += this.stack_height + this.y_num_height / 2;
                if (allow_space_for_names) {
                    this.summed_height += this.fine_txt_height + this.fine_txt_above + this.name_height;
                    this.summed_height += Math.max(this.y_num_height / 2, this.x_num_height + this.x_num_above + this.name_spacer);
                }
                else {
                    this.summed_height += Math.max(this.y_num_height / 2, this.x_num_height + this.x_num_above + this.fine_txt_height + this.fine_txt_above);
                }
                //calculate how much horizontal space we want to draw this
                //first add the padding at the left and right since that's always there
                this.summed_width += this.pad_left + this.pad_right;
                //add on the space for the y-axis label
                this.summed_width += this.y_label_height + this.y_label_spacer;
                //add on the space for the y-axis
                this.summed_width += this.y_num_width + this.y_tic_width;
                //add on the space for the stacks
                this.summed_width += (this.stack_pad_left + this.stack_width) * logo_columns;
                //add on the padding after the stacks (an offset from the fine text)
                this.summed_width += this.stacks_pad_right;
            }
            return LogoMetrics;
        }());
        Workbench.LogoMetrics = LogoMetrics;
    })(Workbench = GCModeller.Workbench || (GCModeller.Workbench = {}));
})(GCModeller || (GCModeller = {}));
var GCModeller;
(function (GCModeller) {
    var Workbench;
    (function (Workbench) {
        var RasterizedAlphabet = /** @class */ (function () {
            function RasterizedAlphabet(alphabet, font, target_width) {
                var default_size, safety_pad, canvas, ctx, middle, baseline, widths, count, letters, i, letter, size, tenpercent, avg_width, scale, target_height, raster;
                //variable prototypes
                this.lookup = []; //a map of letter to index
                this.rasters = []; //a list of rasters
                this.dimensions = []; //a list of dimensions
                //construct
                default_size = 60; // size of square to assume as the default width
                safety_pad = 20; // pixels to pad around so we don't miss the edges
                // create a canvas to do our rasterizing on
                canvas = document.createElement("canvas");
                // assume the default font would fit in a canvas of 100 by 100
                canvas.width = default_size + 2 * safety_pad;
                canvas.height = default_size + 2 * safety_pad;
                // check for canvas support before attempting anything
                if (!canvas.getContext) {
                    throw new Error("NO_CANVAS_SUPPORT");
                }
                ctx = canvas.getContext('2d');
                // check for html5 text drawing support
                if (!supports_text(ctx)) {
                    throw new Error("NO_CANVAS_TEXT_SUPPORT");
                }
                // calculate the middle
                middle = Math.round(canvas.width / 2);
                // calculate the baseline
                baseline = Math.round(canvas.height - safety_pad);
                // list of widths
                widths = [];
                count = 0;
                letters = [];
                //now measure each letter in the alphabet
                for (i = 0; i < alphabet.get_size(); ++i) {
                    if (alphabet.is_ambig(i)) {
                        continue; //skip ambigs as they're never rendered
                    }
                    letter = alphabet.get_letter(i);
                    letters.push(letter);
                    this.lookup[letter] = count;
                    //clear the canvas
                    canvas.width = canvas.width;
                    // get the context and prepare to draw our width test
                    ctx = canvas.getContext('2d');
                    ctx.font = font;
                    ctx.fillStyle = alphabet.get_colour(i);
                    ctx.textAlign = "center";
                    ctx.translate(middle, baseline);
                    // draw the test text
                    ctx.fillText(letter, 0, 0);
                    //measure
                    size = canvas_bounds(ctx, canvas.width, canvas.height);
                    if (size.width === 0) {
                        throw new Error("INVISIBLE_LETTER"); //maybe the fill was white on white?
                    }
                    widths.push(size.width);
                    this.dimensions[count] = size;
                    count++;
                }
                //sort the widths
                widths.sort(function (a, b) { return a - b; });
                //drop 10% of the items off each end
                tenpercent = Math.floor(widths.length / 10);
                for (i = 0; i < tenpercent; ++i) {
                    widths.pop();
                    widths.shift();
                }
                //calculate average width
                avg_width = 0;
                for (i = 0; i < widths.length; ++i) {
                    avg_width += widths[i];
                }
                avg_width /= widths.length;
                // calculate scales
                for (i = 0; i < this.dimensions.length; ++i) {
                    size = this.dimensions[i];
                    // calculate scale
                    scale = target_width / Math.max(avg_width, size.width);
                    // estimate scaled height
                    target_height = size.height * scale;
                    // create an approprately sized canvas
                    raster = document.createElement("canvas");
                    raster.width = target_width; // if it goes over the edge too bad...
                    raster.height = target_height + safety_pad * 2;
                    // calculate the middle
                    middle = Math.round(raster.width / 2);
                    // calculate the baseline
                    baseline = Math.round(raster.height - safety_pad);
                    // get the context and prepare to draw the rasterized text
                    ctx = raster.getContext('2d');
                    ctx.font = font;
                    ctx.fillStyle = alphabet.get_colour(i);
                    ctx.textAlign = "center";
                    ctx.translate(middle, baseline);
                    ctx.save();
                    ctx.scale(scale, scale);
                    // draw the rasterized text
                    ctx.fillText(letters[i], 0, 0);
                    ctx.restore();
                    this.rasters[i] = raster;
                    this.dimensions[i] = canvas_bounds(ctx, raster.width, raster.height);
                }
            }
            RasterizedAlphabet.prototype.draw = function (ctx, letter, dx, dy, dWidth, dHeight) {
                var index, raster, size;
                index = this.lookup[letter];
                raster = this.rasters[index];
                size = this.dimensions[index];
                ctx.drawImage(raster, 0, size.bound_top - 1, raster.width, size.height + 1, dx, dy, dWidth, dHeight);
            };
            RasterizedAlphabet.canvas_bounds = function (ctx, cwidth, cheight) {
                var data, r, c, top_line, bottom_line, left_line, right_line, txt_width, txt_height;
                data = ctx.getImageData(0, 0, cwidth, cheight).data;
                r = 0;
                c = 0; // r: row, c: column
                top_line = -1;
                bottom_line = -1;
                left_line = -1;
                right_line = -1;
                txt_width = 0;
                txt_height = 0;
                // Find the top-most line with a non-white pixel
                for (r = 0; r < cheight; r++) {
                    for (c = 0; c < cwidth; c++) {
                        if (data[r * cwidth * 4 + c * 4 + 3]) {
                            top_line = r;
                            break;
                        }
                    }
                    if (top_line != -1) {
                        break;
                    }
                }
                //find the last line with a non-white pixel
                if (top_line != -1) {
                    for (r = cheight - 1; r >= top_line; r--) {
                        for (c = 0; c < cwidth; c++) {
                            if (data[r * cwidth * 4 + c * 4 + 3]) {
                                bottom_line = r;
                                break;
                            }
                        }
                        if (bottom_line != -1) {
                            break;
                        }
                    }
                    txt_height = bottom_line - top_line + 1;
                }
                // Find the left-most line with a non-white pixel
                for (c = 0; c < cwidth; c++) {
                    for (r = 0; r < cheight; r++) {
                        if (data[r * cwidth * 4 + c * 4 + 3]) {
                            left_line = c;
                            break;
                        }
                    }
                    if (left_line != -1) {
                        break;
                    }
                }
                //find the right most line with a non-white pixel
                if (left_line != -1) {
                    for (c = cwidth - 1; c >= left_line; c--) {
                        for (r = 0; r < cheight; r++) {
                            if (data[r * cwidth * 4 + c * 4 + 3]) {
                                right_line = c;
                                break;
                            }
                        }
                        if (right_line != -1) {
                            break;
                        }
                    }
                    txt_width = right_line - left_line + 1;
                }
                //return the bounds
                return {
                    bound_top: top_line, bound_bottom: bottom_line,
                    bound_left: left_line, bound_right: right_line, width: txt_width,
                    height: txt_height
                };
            };
            return RasterizedAlphabet;
        }());
        Workbench.RasterizedAlphabet = RasterizedAlphabet;
    })(Workbench = GCModeller.Workbench || (GCModeller.Workbench = {}));
})(GCModeller || (GCModeller = {}));
var GCModeller;
(function (GCModeller) {
    var Workbench;
    (function (Workbench) {
        var Symbol = /** @class */ (function () {
            function Symbol(alph_index, scale, alphabet) {
                this.symbol = alphabet.get_letter(alph_index);
                this.scale = scale;
                this.colour = alphabet.get_colour(alph_index);
            }
            Symbol.prototype.toString = function () {
                return this.symbol + " " + (Math.round(this.scale * 1000) / 10) + "%";
            };
            Symbol.compareSymbol = function (sym1, sym2) {
                if (sym1.scale < sym2.scale) {
                    return -1;
                }
                else if (sym1.scale > sym2.scale) {
                    return 1;
                }
                else {
                    return 0;
                }
            };
            return Symbol;
        }());
        Workbench.Symbol = Symbol;
    })(Workbench = GCModeller.Workbench || (GCModeller.Workbench = {}));
})(GCModeller || (GCModeller = {}));
//# sourceMappingURL=linq.js.map