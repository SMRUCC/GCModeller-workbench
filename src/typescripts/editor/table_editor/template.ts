namespace uikit.table_editor.template {

    /**
     * 定义了如何生成表格之中的行数据进行编辑操作的按钮的html用户界面
    */
    export const editor_template: string = `
        <div id="row-new-pending">
            <span class="label label-success"><a href="${executeJavaScript}" id="confirm">{1}</a></span>&nbsp;
            <span class="label label-warning"><a href="${executeJavaScript}" id="cancel">{2}</a></span>
        </div>
        <div id="remove-button" style="display:none;">            
            <span class="label label-warning"><a href="${executeJavaScript}" id="remove">{3}</a></span>            
            <span class="label label-info"><a href="${executeJavaScript}" id="edit">{4}</a></span>          
        </div>
        <div id="edit-button" style="display:none;">            
            <span class="label label-success"><a href="${executeJavaScript}" id="ok">{5}</a></span>
            <span class="label label-warning"><a href="${executeJavaScript}" id="cancel-edit">{2}</a></span>
        </div>`;
}