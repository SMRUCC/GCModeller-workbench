<!DOCTYPE html>
<html lang="en">

<?vb $title = "Data Embedding" ?>
<?vb $app = "dataEmbedding" ?>

<head>
    <%= ../assets/includes/head.vbhtml %>

        <meta name="web_invoke_enrichment" content="http://localhost:7452/analysis_apps/enrichment">
        <meta name="web_invoke_Rplot" content="http://localhost:7452/analysis_apps/enrichment_plot">
</head>

<body>
    <!-- Start your project here-->
    <div class="container">

        <!-- Tabs navs -->
        <ul class="nav nav-tabs mb-3" id="ex-with-icons" role="tablist">
            <li class="nav-item" role="presentation">
                <a class="nav-link active" id="ex-with-icons-tab-1" data-mdb-toggle="tab" href="#ex-with-icons-tabs-1"
                    role="tab" aria-controls="ex-with-icons-tabs-1" aria-selected="true"><i
                        class="fas fa-chart-pie fa-fw me-2"></i>Configurations</a>
            </li>
            <li class="nav-item" role="presentation">
                <a class="nav-link" id="ex-with-icons-tab-2" data-mdb-toggle="tab" href="#ex-with-icons-tabs-2"
                    role="tab" aria-controls="ex-with-icons-tabs-2" aria-selected="false">
                    <i class="fas fa-cogs fa-fw me-2"></i>
                    Analysis
                    Result
                </a>
            </li>
        </ul>
        <!-- Tabs navs -->

        <!-- Tabs content -->
        <div class="tab-content" id="ex-with-icons-content">
            <div class="tab-pane fade show active" id="ex-with-icons-tabs-1" role="tabpanel"
                aria-labelledby="ex-with-icons-tab-1">

                <!-- Parameter content and data files at here -->



                <div class="row">
                    <div class="col-auto">
                        <button id="run" type="submit" class="btn btn-primary mb-3">Run</button>
                    </div>
                </div>

            </div>
            <div class="tab-pane fade" id="ex-with-icons-tabs-2" role="tabpanel" aria-labelledby="ex-with-icons-tab-2">


                <!-- Show data analysis result at here -->

            </div>

        </div>
        <!-- Tabs content -->

        <%= ../assets/includes/webapp.vbhtml %>

    </div>
    <!-- End your project here-->
</body>

</html>