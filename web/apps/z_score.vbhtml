<!DOCTYPE html>
<html lang="en">

<?vb $title = "Z-score analysis" ?>
<?vb $app = "z_score" ?>

<head>
    <%= ../assets/includes/head.vbhtml %>

        <meta name="web_invoke_enrichment" content="http://localhost:7452/analysis_apps/enrichment">
        <meta name="web_invoke_Rplot" content="http://localhost:7452/analysis_apps/enrichment_plot">
</head>

<body>
    <!-- Start your project here-->
    <div class="container">

        <div class="row">
            <div class="col-md-8">
                <!-- Spied element -->
                <div data-mdb-spy="scroll" data-mdb-target="#scrollspy1" data-mdb-offset="0" class="scrollspy-example">
                    <section id="example-1">
                        <h3>Introduction</h3>

                        <div class="clearfix">
                            <img class="col-md-6 float-md-end mb-3 ms-md-3 hover-shadow hover-zoom"
                                src="/assets/images/What-Is-A-Z-Score.png" style="width: 300px;">

                            <p>
                                In statistics, the standard score is the number of standard deviations by which the
                                value of a raw score (i.e., an observed value or data point) is above or below the mean
                                value of what is being observed or measured. Raw scores above the mean have positive
                                standard scores, while those below the mean have negative standard scores.
                            </p>
                            <p>
                                It is calculated by subtracting the population mean from an individual raw score and
                                then dividing the difference by the population standard deviation. This process of
                                converting a raw score into a standard score is called standardizing or normalizing
                                (however, "normalizing" can refer to many types of ratios; see normalization for more).
                            </p>
                            <p>
                                Standard scores are most commonly called z-scores; the two terms may be used
                                interchangeably, as they are in this article. Other equivalent terms in use include
                                z-values, normal scores, standardized variables and pull in high energy physics.
                            </p>
                        </div>

                    </section>
                    <section id="example-2">
                        <h3>Set Parameters</h3>
                        ...
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