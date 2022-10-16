interface IsampleMeta {
    sampleInfo: string;
    shape: number;
    color: string;
    color1: string;
    color2: string;
}

interface saveAction {
    (meta: IsampleMeta[]): void;
}
