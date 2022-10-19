<!DOCTYPE html>
<html lang="en">

<?vb $title = "Applications" ?>
<?vb $app = "applets" ?>

<head>
    <%= ./assets/includes/head.vbhtml %>

        <meta name="web_invoke_imports" content="http://localhost:7452/database/imports_uniprot">
        <meta name="web_invoke_inspector" content="http://localhost:7452/database/inspect_database">

        <style type="text/css">
            .card-body {
                padding: 0.25rem;
                padding-left: 0.75rem;
            }

            .icon-image {
                width: 64px;
                height: 64px;
            }

            .background {
                position: relative;
                background-image: url("/assets/images/dna-image-blur.png");
                background-position: center;
                background-repeat: no-repeat;
                background-size: cover;
                /* height: 100%;
                filter: blur(8px);
                 */
            }
        </style>
</head>

<body class="background">
    <!-- Start your project here-->
    <div class="container" style="background: rgba(0, 0, 0, 0.6); padding: 30px 30px 30px 30px; height: 100%;">

        <h1 style="color: white;">GCModeller Analysis Applications</h1>
        <br />
        <div class="row" id="applets">

        </div>

        <%= ./assets/includes/webapp.vbhtml %>


            <footer class="text-center text-lg-start text-muted" style="font-size: 0.9em;">
                <!-- Copyright -->
                <div class="text-center p-4" style="background-color: rgba(0, 0, 0, 0.05); color: white;">
                    © 2022 Copyright:
                    <a class="text-reset fw-bold" href="https://gcmodeller.org/">GCModeller.org</a> | 中國 · 桂林
                </div>
                <!-- Copyright -->
            </footer>

    </div>
    <!-- End your project here-->
</body>

</html>