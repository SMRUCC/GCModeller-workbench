namespace sampleinfo_editor.colorPicker {

    /**
     * @param setColor set color code, this lambda function argument 
     *                 requires a string parameter for accept the 
     *                 html code of the given color.
    */
    export function fast(
        id: string,
        list: string[],
        setColor: Delegate.Sub,
        defaultColor: string = "#000000",
        more: Delegate.Action = null): colorPickerUI {

        return new colorPickerUI(id, defaultColor)
            .addOptions(list)
            .tryHandleMoreColors(more)
            .hookSetColor(setColor);
    }

    export function init2_colorPickUI() {
        sampleinfo_editor.colorPicker.doStyle();
    }
}
