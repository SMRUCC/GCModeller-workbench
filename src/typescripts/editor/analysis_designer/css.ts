namespace biodeep {

    export function loadStyle() {
        let css = $ts("<style>").display(
`.widget_group {
    border-radius: 5px;
    padding: 5px 30px 5px 20px;
    margin-bottom: 10px;
    margin-top: 10px;
    background-color: #1ea2e9;
    border: 1px solid #428bca;
    color: #ffffff;
    margin-right: 10px;
    float: left;
    cursor: pointer;
    position: relative;
}

div.ui-selected {
    -webkit-transition: border linear .2s,-webkit-box-shadow linear .5s;
    border-color: rgba(141,39,142,.75);
    -webkit-box-shadow: 0 0 18px rgba(111, 1, 32, 1);
    border: 1px solid red;
    background-color: #F39814;
}

.radio-iscurrent {
    float: left;
    padding-top: 13px;
    margin-right: 5px;
}

ul.ui-sortable {
    float: left;
}
.groupCount {
    display: flex;
    justify-content: space-between;
    padding: 0 40px;
}
#all_groups {
    padding: 0 10px;
}
.firstLi,
.lastLi {
    width: 45%;
    border: 1px solid #03a9f4;
}
h3,p {
    text-align: center;
}
.groEnt {
    width: 5%;
    text-align: center;
    margin-top: 10%;
}
.groEnt a {
    font-size: 36px;
}
.samplegroup-div {
    padding: 0 10px;
    margin-bottom: 15px;
}
.ui-sortable {
    border: 1px dashed #03a9f4;
    padding: 0 10px;
}

`);
        $ts("&head").appendElement(css);
    }
}