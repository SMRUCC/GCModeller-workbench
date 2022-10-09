<!DOCTYPE html>
<html lang="en">

<?vb $title = "Fuzzy CMeans Expression Patterns" ?>
<?vb $app = "cmeans_pattern" ?>

<head>
    <%= ../assets/includes/head.vbhtml %>

        <meta name="web_invoke_enrichment" content="http://localhost:7452/analysis_apps/enrichment">
        <meta name="web_invoke_Rplot" content="http://localhost:7452/analysis_apps/enrichment_plot">
</head>

<body>
    <!-- Start your project here-->
    <div class="container">

        <h1>Time Course Sequencing Data Analysis</h1>

        <div class="row">
            <div class="col-md-8">
                <!-- Spied element -->
                <div data-mdb-spy="scroll" data-mdb-target="#scrollspy1" data-mdb-offset="0" class="scrollspy-example">
                    <section id="example-1">
                        <h3>Introduction</h3>

                        <div class="clearfix">
                            <img class="col-md-6 float-md-end mb-3 ms-md-3 hover-shadow hover-zoom"
                                src="/assets/images/gallery/CMeans.PNG" style="width: 300px;">

                            <p>
                                Quantitative and differential analysis of epigenomic and transcriptomic time course
                                sequencing data, clustering analysis and visualization of temporal patterns of time
                                course data.
                            </p>
                            <p>
                                Two types of clustering algorithms are included in the analysis: hard clustering
                                (kmeans) and soft clustering (fuzzy cmeans). The temporal patterns are analyzed
                                based on the pattern clustering result between multiple sample groups data.
                                Instead of absolute value of different time series, one might only focus on the change
                                patterns and expect time series with similar pattern to be cluster in same group. In
                                this case, "standardize" parameter gives an option to perform z-score transformation on
                                the data to be clustered, which reduces the noises introduced by the difference in the
                                absolute values. </p>
                        </div>

                    </section>
                    <section id="example-2">
                        <h3>Set Parameters</h3>

                        <div class="row">
                            <div class="col-auto">
                                <p>Algorithm method to used:</p>

                                <select id="algorithm" class="form-select select-input placeholder-active">
                                    <option value="kmeans">KMeans</option>
                                    <option value="cmeans" selected>CMeans</option>
                                </select>

                            </div>
                        </div>

                        <div class="row">
                            <div class="col-auto">
                                <!-- Checked checkbox -->
                                <div class="form-check">
                                    <input class="form-check-input" type="checkbox" value="" id="z-score" checked />
                                    <label class="form-check-label" for="z-score">Z-score transformation</label>
                                </div>

                                <p>
                                    A Z-score is a numerical measurement that describes a value's relationship
                                    to the mean of a group of values. Z-score is measured in terms of standard
                                    deviations from the mean. If a Z-score is 0, it indicates that the data
                                    point's score is identical to the mean score. A Z-score of 1.0 would
                                    indicate a value that is one standard deviation from the mean. Z-scores may
                                    be positive or negative, with a positive value indicating the score is above
                                    the mean and a negative score indicating it is below the mean.
                                </p>

                                <div class="row">
                                    <div class="col-4">
                                        <p>Layout:</p>

                                        <p>Columns x Rows: </p> <input type="text" class="form-control" id="cols"
                                            value="3" /> x
                                        <input type="text" class="form-control" id="rows" value="3" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-12">

                                <p>
                                    The matrix file format should be:<br />

                                <ol>
                                    <li>Each row data is the data entity list</li>
                                    <li>Each column data is the feature data vector of the data entity in rows.</li>
                                </ol>

                                For omics data that could be:<br />
                                <ol>
                                    <li>
                                        Each row data should be the samples.
                                    </li>
                                    <li>
                                        Each column data should be the gene features
                                    </li>
                                </ol>
                                </p>

                                <label for="matrix-file" class="form-label">Select Matrix:</label>
                                <div class="input-group mb-3">
                                    <button class="btn btn-primary" type="button" id="button_open"
                                        data-mdb-ripple-color="dark">
                                        <i class="far fa-folder-open"></i> Select File
                                    </button>
                                    <input type="text" class="form-control" placeholder="" id="matrix-file"
                                        aria-label="Example text with button addon" aria-describedby="button-addon1" />
                                </div>
                            </div>
                        </div>

                        <br />
                        <div class="row">
                            <div class="col-auto">
                                <button id="run" type="submit" class="btn btn-primary mb-3">Run</button>
                            </div>
                        </div>

                    </section>
                    <section id="example-3">
                        <h3>Analysis Result</h3>
                        ...
                        <section id="example-sub-A">
                            <h3>Rplot</h3>
                            ...
                        </section>
                        <section id="example-sub-B">
                            <h3>Data Table</h3>
                            ...
                        </section>
                    </section>
                    <section id="example-4">
                        <h3>Reference</h3>
                        ...
                    </section>
                    <section id="example-5">
                        <h3>Download</h3>
                        ...
                    </section>
                </div>
                <!-- Spied element -->
            </div>

            <div class="col-md-4">
                <!-- Scrollspy -->
                <div id="scrollspy1" class="sticky-top">
                    <ul class="nav flex-column nav-pills menu-sidebar">
                        <li class="nav-item">
                            <a class="nav-link" href="#example-1">Introduction</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#example-2">Set Parameters</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#example-3">Analysis Result</a>
                            <ul class="nav flex-column ps-3">
                                <li class="nav-item">
                                    <a class="nav-link" href="#example-sub-A">Rplot</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" href="#example-sub-B">Data Table</a>
                                </li>
                            </ul>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#example-4">Reference</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#example-5">Download</a>
                        </li>
                    </ul>
                </div>
                <!-- Scrollspy -->
            </div>
        </div>




        <%= ../assets/includes/webapp.vbhtml %>

    </div>
    <!-- End your project here-->
</body>

</html>