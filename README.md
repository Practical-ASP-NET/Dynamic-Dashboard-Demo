A small demo app showing one way to render a "dynamic dashboard" using .NET 6.

To launch the app make sure to run the **Server** project.

The Server project serves the Blazor WASM app to the browser and also acts as the API for the application.

To make new widgets available for your dashboard create a new Blazor component in the Features\Widgets folder (in the Client app).

## Architecture Notes
Please note the backend API uses a SQLite database to store which widgets have been added to the dashboard.

The Blazor WASM application uses Tailwind CSS for styling.
