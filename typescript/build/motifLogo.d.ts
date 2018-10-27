/// <reference path="linq.d.ts" />
declare namespace GCModeller.Workbench {
    /**
     * Fast string trimming implementation found at
     * http://blog.stevenlevithan.com/archives/faster-trim-javascript
     *
     * Note that regex is good at removing leading space but
     * bad at removing trailing space as it has to first go through
     * the whole string.
    */
    function trim(str: string): string;
}
declare namespace GCModeller.Workbench {
    /**
     * Draw motif logo from this function
    */
    class LoadQueryTask {
        target_id: any;
        motifPWM: any;
        scaleLogo: any;
        constructor(target_id: any, pwm: any, scale: any);
        run(): void;
    }
}
declare namespace GCModeller.Workbench {
    class MotifLogo {
        show_opts_link: any;
        task_queue: any[];
        task_delay: number;
        my_alphabet: any;
        query_pspm: any;
        scaleLogo: any;
        motifPWM: any;
        drawLogo(div_id: any, pwm: any, scale: any): void;
        draw_scale(ctx: any, metrics: any, alphabet_ic: any): void;
        draw_stack_num(ctx: any, metrics: any, row_index: any): void;
        draw_stack(ctx: any, metrics: any, symbols: any, raster: any): void;
        draw_dashed_line(ctx: any, pattern: any, start: any, x1: any, y1: any, x2: any, y2: any): void;
        draw_trim_background(ctx: any, metrics: any, pspm: any, offset: any): void;
        size_logo_on_canvas(logo: any, canvas: any, show_names: any, scale: any): void;
        draw_logo_on_canvas(logo: any, canvas: any, show_names: any, scale: any): void;
        logo_1(alphabet: any, fine_text: any, pspm: any): Logo;
        replace_logo(logo: any, replace_id: any, scale: any, title_txt: any, display_style: any): void;
        push_task(task: any): void;
        process_tasks(): void;
    }
}
declare namespace GCModeller.Workbench {
    class Alphabet {
        static readonly is_letter: RegExp;
        static readonly is_prob: RegExp;
        freqs: number[];
        alphabet: string[];
        private letter_count;
        readonly ic: number;
        readonly size: number;
        readonly isNucleotide: boolean;
        constructor(alphabet: string, bg?: string);
        private parseBackground;
        toString(): string;
        getLetter(index: number): string;
        getBgfreq(index: number): number;
        getColour(index: number): string;
        isAmbig(index: number): boolean;
        getIndex(letter: string): number;
    }
}
declare namespace GCModeller.Workbench.AlphabetColors {
    const red: string;
    const blue: string;
    const orange: string;
    const green: string;
    const yellow: string;
    const purple: string;
    const magenta: string;
    const pink: string;
    const turquoise: string;
    function nucleotideColor(alphabet: string): string;
    function proteinColor(alphabet: string): string;
}
declare namespace GCModeller.Workbench {
    class Logo {
        alphabet: any;
        fine_text: any;
        pspm_list: any;
        pspm_column: any;
        rows: number;
        columns: number;
        constructor(alphabet: any, fine_text: any);
        addPspm(pspm: any, column: any): void;
        getPspm(rowIndex: number): any;
        getOffset(rowIndex: any): any;
    }
}
declare namespace GCModeller.Workbench {
    class LogoMetrics {
        pad_top: number;
        pad_left: number;
        pad_right: number;
        pad_bottom: number;
        pad_middle: number;
        name_height: number;
        name_font: any;
        name_spacer: number;
        y_label: any;
        y_label_height: number;
        y_label_font: any;
        y_label_spacer: number;
        y_num_height: number;
        y_num_width: number;
        y_num_font: any;
        y_tic_width: number;
        stack_pad_left: number;
        stack_font: string;
        stack_height: number;
        stack_width: number;
        stacks_pad_right: number;
        x_num_above: number;
        x_num_height: number;
        x_num_width: number;
        x_num_font: any;
        fine_txt_height: number;
        fine_txt_above: number;
        fine_txt_font: any;
        letter_metrics: any[];
        summed_width: number;
        summed_height: number;
        constructor(ctx: any, logo_columns: any, logo_rows: any, allow_space_for_names: any);
    }
}
declare namespace GCModeller.Workbench {
    class Pspm {
        name: string;
        alph_length: any;
        motif_length: any;
        nsites: any;
        evalue: any;
        ltrim: any;
        rtrim: any;
        pspm: any[];
        constructor(matrix: any, name?: string, ltrim?: any, rtrim?: any, nsites?: any, evalue?: any);
        private parseInternal;
        private copyInternal;
        copy(): Pspm;
        reverse_complement(alphabet: any): this;
        get_stack(position: any, alphabet: any): any;
        get_stack_ic(position: any, alphabet: any): number;
        get_error(alphabet: any): number;
        get_motif_length(): any;
        get_alph_length(): any;
        get_left_trim(): any;
        get_right_trim(): any;
        as_pspm(): any;
        as_pssm(alphabet: any, pseudo: any): any;
        toString(): string;
    }
}
declare namespace GCModeller.Workbench {
    function static(): any;
    function parse_pspm_string(pspm_string: string): {
        "pspm": any;
        "motif_length": any;
        "alph_length": any;
        "nsites": any;
        "evalue": any;
    };
}
declare namespace GCModeller.Workbench {
    class RasterizedAlphabet {
        lookup: any;
        rasters: any;
        dimensions: any;
        constructor(alphabet: any, font: any, target_width: any);
        draw(ctx: any, letter: any, dx: any, dy: any, dWidth: any, dHeight: any): void;
        static canvas_bounds(ctx: any, cwidth: any, cheight: any): {
            bound_top: any;
            bound_bottom: any;
            bound_left: any;
            bound_right: any;
            width: any;
            height: any;
        };
    }
}
declare namespace GCModeller.Workbench {
    class Symbol {
        symbol: string;
        scale: number;
        colour: string;
        constructor(index: number, scale: number, alphabet: Alphabet);
        toString(): string;
        static compareSymbol(sym1: Symbol, sym2: Symbol): number;
    }
}
