namespace biodeep {

    export function createInputModal(id: string, title: string, description: string) {
        let modalDoc = $ts("<div>", {
            class: "modal-dialog",
            role: "document"
        }).display($ts("<div>", {
            class: "modal-content"
        }).display(`       
            <div class="modal-header">  
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">  
                    <span aria-hidden="true">×</span>  
                </button>  
                <h4 class="modal-title" id="myModalLabel">${title}</h4>  
            </div>  
            <div class="modal-body">
                <p><input id="sample-${id}" type="text" class="form-control" placeholder="${description}"></input></p>  
            </div>  
            <div class="modal-footer">  
                <button type="button" class="btn btn-default" data-dismiss="modal">取消</button>  
                <button field="${id}" type="button" class="group_checked btn btn-primary" data-dismiss="modal">确定</button>  
            </div>`));
        let modal = $ts("<div>", {
            class: ["modal", "fade"],
            id: id,
            tabindex: -1,
            role: "dialog",
            "aria-labelledby": "myModalLabel"
        }).display(modalDoc);

        $ts("&body").appendElement(modal);
    }
}