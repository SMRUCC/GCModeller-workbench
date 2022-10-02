var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    }
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
/// <reference path="../build/linq.d.ts" />
var apps;
(function (apps) {
    function run() {
        Router.AddAppHandler(new pages.enrichment_database());
        Router.RunApp();
    }
    apps.run = run;
})(apps || (apps = {}));
$ts.mode = Modes.debug;
$ts(apps.run);
var pages;
(function (pages) {
    var enrichment_database = /** @class */ (function (_super) {
        __extends(enrichment_database, _super);
        function enrichment_database() {
            return _super !== null && _super.apply(this, arguments) || this;
        }
        Object.defineProperty(enrichment_database.prototype, "appName", {
            get: function () {
                return "enrichment_database";
            },
            enumerable: true,
            configurable: true
        });
        enrichment_database.prototype.init = function () {
            // throw new Error("Method not implemented.");
        };
        enrichment_database.prototype.open_uniprot_onclick = function () {
            $ts.get("@web_invoke_openfile", function (result) {
                $ts("#formFile").CType().value = result.info;
            });
        };
        enrichment_database.prototype.imports_onclick = function () {
            var data = {
                file: $ts.value("#formFile"),
                name: $ts.value("#title"),
                note: $ts.value("#description")
            };
            $ts.post("@web_invoke_imports", data, function (result) {
                if (result.code != 0) {
                }
                else {
                    // location.reload();
                }
            });
        };
        return enrichment_database;
    }(Bootstrap));
    pages.enrichment_database = enrichment_database;
})(pages || (pages = {}));
//# sourceMappingURL=biocad_desktop.js.map