namespace biodeep.UI_events {

    export function handlerEvent(handler: updateDesigns): addDesign {
        let handleUpdate: Delegate.Action;

        handler = isNullOrUndefined(handler) ? DoNothing : handler;
        handleUpdate = function () {
            handler(getCurrentDesigns());
        }

        return function (labels) {
            if (isNullOrEmpty(labels) || labels.length < 2) {
                return;
            } else {
                console.log(labels);
            }

            // 判断当前的列表
            if (!$ts(getCurrentDesigns())
                .Any(function (a) {
                    // 跳过已经存在的比对组别
                    let all = $from([...a.group_info].concat([...labels]));
                    let unique = all.Distinct();

                    return (a.groups == labels.length) && (labels.length == unique.Count);
                })) {

                let designContainer = $ts("#designs")

                designContainer.appendElement(analysisDesignItem(labels, designContainer, handleUpdate));
                clearSelectes();

                // 重新计算已经更新过的列表
                handleUpdate();
            }
        }
    }

    function clearSelectes() {
        labels.popall();

        // reset ui
        $ts($ts("#all_groups").getElementsByTagName("div"))
            .Where(div => div.classList.contains("ui-selected"))
            .ForEach(div => div.classList.remove("ui-selected"));
    }

    export function doLabeler(label: string): HTMLElement {
        let labelDiv: IHTMLElement = $ts("<div>", {
            class: ["widget_group"],
            "data-target": label
        }).display(label);

        labelDiv.onclick = function () {
            if (labelDiv.classList.contains("ui-selected")) {
                labelDiv.classList.remove("ui-selected");
                labels.delete(label);
            } else {
                labelDiv.classList.add("ui-selected");
                labels.add(label);
            }
        }

        return labelDiv;
    }

    export function getCurrentDesigns(): analysisDesign[] {
        return $ts.select(".samplegroup-div")
            .Select(a => getDesign(a))
            .ToArray(false);
    }

    function getDesign(label: HTMLElement): analysisDesign {
        let labels: string[] = JSON.parse(label.getAttribute("data-target"));

        return <analysisDesign>{
            groups: labels.length,
            group_info: labels,
            label: labels.join(" vs ")
        }
    }
}