<!DOCTYPE html>
<html lang="en">

<?vb $title = "Data Repository" ?>
<?vb $app = "data_repository" ?>

<head>
    <%= ./assets/includes/head.vbhtml %>

        <style type="text/css">
            .background {
                /* position: relative; */

                background-image: url('/assets/images/database-management-system.jpg');
                background-position: center;
                background-repeat: no-repeat;
                background-size: cover;
            }
        </style>
</head>

<body>
    <!-- Start your project here-->
    <div class="container background">

        <h1>Data Repository</h1>

        <a href="#" onclick="apps.gcmodeller.openEnrichmentRepository();">Enrichment Data Repository</a>
        <a href="#" onclick="apps.gcmodeller.openEnzymeRepository();">Enzyme Data Repository</a>


        <%= ./assets/includes/webapp.vbhtml %>
    </div>
    <!-- End your project here-->
</body>

</html>