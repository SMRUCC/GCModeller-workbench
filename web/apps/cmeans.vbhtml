<!DOCTYPE html>
<html lang="en">

<?vb $title = "Fuzzy CMeans Expression Patterns" ?>
<?vb $app = "cmeans_pattern" ?>

<head>
    <%= ../assets/includes/head.vbhtml %>

        <meta name="web_invoke_clustering" content="http://localhost:7452/analysis_apps/patternCMeans">
        <meta name="web_invoke_Rplot" content="http://localhost:7452/analysis_apps/Rplots/patterns_plot">
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
                                    <input class="form-check-input" type="checkbox" value="" name="z-score" id="z-score" checked />
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

                                        <div class="input-group mb-3">
                                            <input type="text" class="form-control" placeholder="Columns"
                                                aria-label="Columns" id="cols" value="3" />
                                            <span class="input-group-text">x</span>
                                            <input type="text" class="form-control" placeholder="Rows" aria-label="Rows"
                                                id="rows" value="3" />
                                        </div>
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

                        <section id="example-sub-A">
                            <h3>Rplot</h3>

                            <section class="pb-4">
                                <div class="bg-white border rounded-5">

                                    <section class="p-4 d-flex justify-content-center text-center w-100">
                                        <div class="lightbox" data-id="lightbox-bm48lj2vb" id="lightbox">
                                            <div class="row">
                                                <div class="col-auto">
                                                    <a href="/assets/images/empty.jpg" data-toggle="lightbox"
                                                        data-caption="2d/3d scatter plot" id="Rplot-box">
                                                        <img src="/assets/images/empty.jpg" alt="2d/3d scatter plot"
                                                            class="img-fluid w-100 my-lightbox-toggle"
                                                            style="max-width: 400px;" id="Rplot_js">
                                                    </a>
                                                </div>

                                            </div>
                                        </div>
                                    </section>

                                </div>
                            </section>

                            <button id="refresh_Rplot" type="submit" class="btn btn-primary mb-3">Refresh</button>

                        </section>
                        <section id="example-sub-B">
                            <h3>Data Table</h3>
                            ...
                        </section>
                    </section>
                    <section id="example-4">
                        <h3>Reference</h3>

                        <ol>
                            <li>
                                Nueda MJ, Tarazona S and Conesa A (2014). “Next maSigPro: updating maSigPro Bioconductor
                                package for RNA-seq time series.” Bioinformatics, 30, p. 2598-2602.
                            </li>
                            <li>
                                Guo, DL., Wang, ZG., Pei, MS. et al. Transcriptome analysis reveals mechanism of early
                                ripening in Kyoho grape with hydrogen peroxide treatment. BMC Genomics 21, 784 (2020).
                                https://doi.org/10.1186/s12864-020-07180-y
                            </li>
                            <li>
                                Wu M, Gu L (2022). TCseq: Time course sequencing data analysis. R package version
                                1.20.0.
                            </li>
                        </ol>

                    </section>
                    <section id="example-5">
                        <h3>Download</h3>

                        <p>Save your analysis result files.</p>

                        <div class="btn-group" role="group" aria-label="Button group with nested dropdown">
                            <button type="button" class="btn btn-info" id="save_project">
                                Save To Project
                            </button>

                            <div class="btn-group" role="group">
                                <button id="download-group" type="button" class="btn btn-primary dropdown-toggle"
                                    data-mdb-toggle="dropdown" aria-expanded="false">
                                    Download Report
                                </button>
                                <ul class="dropdown-menu" aria-labelledby="download-group">
                                    <li><a class="dropdown-item" href="#" id="download_zip">Download Zip Archive</a>
                                    </li>
                                    <li><a class="dropdown-item" href="#">Print As PDF</a></li>
                                </ul>
                            </div>
                        </div>
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