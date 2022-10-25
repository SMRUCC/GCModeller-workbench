<!DOCTYPE html>
<html lang="en">

<?vb $title = "Tasks" ?>
<?vb $app = "web_task" ?>

<head>
    <%= ./assets/includes/head.vbhtml %>

        <meta name="web_invoke_imports" content="http://localhost:7452/database/imports_uniprot">
        <meta name="web_invoke_inspector" content="http://localhost:7452/database/inspect_database">
</head>

<body>
    <!-- Start your project here-->
    <div class="container">

        <table class="table align-middle mb-0 bg-white">
            <thead class="bg-light">
                <tr>
                    <th>Name</th>
                    <th>Title</th>
                    <th>Status</th>
                    <th>Log Text</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody id="task_manager">

            </tbody>
        </table>

        <%= ./assets/includes/webapp.vbhtml %>

    </div>
    <!-- End your project here-->
</body>

</html>