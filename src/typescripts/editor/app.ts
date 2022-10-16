/// <reference path="../build/linq.d.ts" />

namespace app {

    /**
     * This method should be call via the ``$ts`` symbol
    */
    export function init() {
        sampleinfo_editor.init0_groupUI();
        sampleinfo_editor.analysis_editor.init1_analysisUI();
        sampleinfo_editor.colorPicker.init2_colorPickUI();
    }
}