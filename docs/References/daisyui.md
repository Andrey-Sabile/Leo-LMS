### Initialize Solid Start project with npm

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/solid-start/+page.md

This command initializes a new Solid Start project in the current directory. It uses `npm init solid@latest` to set up the basic project structure and dependencies.

```sh
npm init solid@latest ./
```

--------------------------------

### Install dependencies and start SvelteKit development server

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/how-to-install-sveltekit-and-daisyui/+page.md

Navigates into the newly created SvelteKit project directory, installs all required Node.js dependencies, and then starts the local development server, opening the application in a browser.

```shell
cd my-app
npm install
npm run dev -- --open
```

--------------------------------

### Start Deno Fresh development server

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/fresh/+page.md

Executes the `deno task start` command to launch the Deno Fresh development server. This command compiles the application and serves it locally, allowing developers to view and interact with the Fresh project.

```sh
deno task start
```

--------------------------------

### Install Dependencies and Start Development Server

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/daisyui-nextjs-online-store-template/+page.md

Instructions to install project dependencies and start the local development server for the daisyUI + Next.js online store template. This allows you to run the application locally for development and testing.

```bash
npm install
```

```bash
npm run dev
```

--------------------------------

### Prompt Examples for daisyUI with MCP Servers

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/editor/claude/+page.md

These examples illustrate how to structure prompts for Claude desktop when using MCP servers for daisyUI development. Appending `use context7` to a prompt directs Claude to utilize the Context7 server for generating daisyUI themes or components, ensuring more relevant and accurate results.

```md
give me a light daisyUI 5 theme with tropical color palette. use context7
```

```md
give me a light daisyUI 5 theme with tropical color palette
```

--------------------------------

### Install Tailwind CSS and daisyUI via npm

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/solid-start/+page.md

This command installs the necessary packages for Tailwind CSS and daisyUI. It includes `tailwindcss`, `@tailwindcss/vite` (for Vite integration), and `daisyui` as project dependencies.

```sh
npm install tailwindcss@latest @tailwindcss/vite@latest daisyui@latest
```

--------------------------------

### daisyUI 5 Configuration Examples

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/static/llms.txt

These CSS snippets illustrate various ways to configure daisyUI 5 using the `@plugin` directive. They cover basic setup, theme selection, and advanced configuration with multiple themes, prefixes, and logging options.

```css
@plugin "daisyui";
```

```css
@plugin "daisyui" {
  themes: light --default;
}
```

```css
@plugin "daisyui" {
  themes: light --default, dark --prefersdark;
  root: ":root";
  include: ;
  exclude: ;
  prefix: ;
  logs: true;
}
```

```css
@plugin "daisyui" {
  themes: light, dark, cupcake, bumblebee --default, emerald, corporate, synthwave --prefersdark, retro, cyberpunk, valentine, halloween, garden, forest, aqua, lofi, pastel, fantasy, wireframe, black, luxury, dracula, cmyk, autumn, business, acid, lemonade, night, coffee, winter, dim, nord, sunset, caramellatte, abyss, silk;
  root: ":root";
  include: ;
  exclude: rootscrollgutter, checkbox;
  prefix: daisy-;
  logs: false;
}
```

--------------------------------

### Run the Eleventy development server

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/11ty/+page.md

Executes the 'dev' npm script, which starts the Eleventy development server. This allows for live previewing of the project and automatically rebuilds on file changes.

```sh
npm run dev
```

--------------------------------

### Import and Link CSS in Web Projects

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/npm-init-daisyui/+page.md

These examples demonstrate common methods for including a generated CSS file in a web project: importing it via JavaScript for bundler-based setups, or linking it directly in HTML for traditional web pages.

```JavaScript
import "/output.css"
```

```HTML
<link href="/output.css" rel="stylesheet" />
```

--------------------------------

### Example Gemini prompt for daisyUI theme generation

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/editor/gemini/+page.md

Demonstrates a complete Gemini prompt that leverages the daisyUI LLM data file to request a specific daisyUI 5 theme. This example shows how to combine the data reference with a natural language request for a customized output.

```text
https://daisyui.com/llms.txt give me a light daisyUI 5 theme with tropical color palette
```

--------------------------------

### Example ChatGPT Prompt for daisyUI Theme Generation

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/editor/chatgpt/+page.md

This example demonstrates how to combine the daisyUI context URL with a specific request. By including `https://daisyui.com/llms.txt` before the prompt, users can ask ChatGPT to generate daisyUI code, such as a light theme with a tropical color palette, ensuring the AI uses the provided documentation.

```Markdown
https://daisyui.com/llms.txt give me a light daisyUI 5 theme with tropical color palette
```

--------------------------------

### Install and Run Nexus Dashboard Template

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/nexus-dashboard-template/+page.md

These commands guide you through installing dependencies, starting the development server, building for production, and previewing the production build for the Nexus dashboard template. Ensure Node.js v18+ is installed and use your preferred package manager (npm, yarn, bun).

```bash
npm install
```

```bash
npm run dev
```

```bash
npm run build
```

```bash
npm run preview
```

--------------------------------

### Create HTML Index File with daisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/elysia/+page.md

Creates a basic `index.html` file in the `public` directory. This file includes the compiled CSS and a simple button element styled with daisyUI classes to demonstrate the setup.

```html
<!DOCTYPE html>
<html>
  <head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="/output.css">
  </head>
  <body>
    <button class="btn btn-primary">Hello daisyUI</button>
  </body>
</html>
```

--------------------------------

### Install Mary UI in a New Laravel Project

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/mary-ui/+page.md

This sequence of commands outlines the complete installation process for Mary UI in a fresh Laravel project, including package installation, setup, and starting the development server.

```bash
composer require robsontenorio/mary
php artisan mary:install
yarn dev
```

--------------------------------

### Install daisyUI 5 via CDN

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/static/llms.txt

This snippet shows how to include daisyUI 5 and Tailwind CSS via CDN links in an HTML file. It's a quick way to get started without a local installation.

```html
<link href="https://cdn.jsdelivr.net/npm/daisyui@5" rel="stylesheet" type="text/css" />
<script src="https://cdn.jsdelivr.net/npm/@tailwindcss/browser@4"></script>
```

--------------------------------

### Example Prompt for GitMCP (Markdown Prompt)

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/editor/vscode/+page.md

This example shows a typical prompt for generating a daisyUI theme when using the daisyUI GitMCP server. The prompt requests a specific theme style and color palette, relying on the GitMCP server for accurate results.

```md:prompt
give me a light daisyUI 5 theme with tropical color palette
```

--------------------------------

### Example Prompt for Context7 MCP (Markdown Prompt)

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/editor/vscode/+page.md

This example demonstrates how to prompt the AI in VSCode's Agent Mode when using the Context7 MCP server. Appending 'use context7' directs the AI to utilize the configured server for generating the requested daisyUI theme.

```md:prompt
give me a light daisyUI 5 theme with tropical color palette. use context7
```

--------------------------------

### Initialize daisyUI with npm

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/npm-init-daisyui/+page.md

This command simplifies the installation and setup of Tailwind CSS, PostCSS, and daisyUI by automating the configuration process. It provides interactive options to either install daisyUI only, or set up Tailwind CSS first (with or without PostCSS).

```Shell
npm init daisyui
```

```Shell
🌼 Initializing daisyUI…

? Do you want to setup Tailwind CSS first?
❯ No need. I already have Tailwind
  Yes. Setup Tailwind first
  Yes. Setup Tailwind first (with PostCSS)
```

--------------------------------

### Install Project Dependencies with npm

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/how-to-make-a-blog-quickly-using-astro-and-daisyUI/+page.md

This command installs all necessary project dependencies listed in the `package.json` file, preparing the Astro blog template for development or production.

```bash
npm install
```

--------------------------------

### Start Rails Development Server

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/rails/+page.md

Command to start the Rails development server, typically using Foreman or a similar process manager.

```sh
./bin/dev
```

--------------------------------

### Create a new Qwik project

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/qwik/+page.md

Initializes a new Qwik project in the current directory using the Qwik CLI.

```sh
npm create qwik@latest empty ./
```

--------------------------------

### Install daisyUI 5 via npm

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/upgrade/+page.md

Install the latest version of daisyUI as a development dependency using npm.

```bash
npm i -D daisyui@latest
```

--------------------------------

### HTML Example: Stacking Card Components with Start Alignment

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/stack/+page.md

Illustrates stacking DaisyUI card components using the `stack` and `stack-start` classes. This setup aligns the layered elements to the horizontal start of the container, useful for left-to-right overlapping effects.

```html
<div class="$$stack $$stack-start size-28">
  <div class="border-base-content $$card bg-base-100 border text-center">
    <div class="$$card-body">A</div>
  </div>
  <div class="border-base-content $$card bg-base-100 border text-center">
    <div class="$$card-body">B</div>
  </div>
  <div class="border-base-content $$card bg-base-100 border text-center">
    <div class="$$card-body">C</div>
  </div>
</div>
```

--------------------------------

### Create a new SvelteKit project

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/how-to-install-sveltekit-and-daisyui/+page.md

Initializes a new SvelteKit application using `npm create svelte@latest`. This command prompts the user to select a project template, typically 'Skeleton project' for a barebones setup.

```shell
npm create svelte@latest my-app
```

--------------------------------

### Import Tailwind CSS and daisyUI in PostCSS

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/solid-start/+page.md

This PostCSS snippet, typically found in `src/app.css`, imports the core Tailwind CSS styles and registers the daisyUI plugin. It ensures that both frameworks are applied to your project's stylesheets.

```postcss
@import "tailwindcss";
@plugin "daisyui";
```

--------------------------------

### Usage Example: Prompt with Context7

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/editor/cline/+page.md

This example demonstrates how to prompt the AI using the Context7 MCP server to generate daisyUI code. Appending 'use context7' to your prompt directs Cline to utilize the Context7 server for processing the request, leveraging its specific data sources.

```markdown
give me a light daisyUI 5 theme with tropical color palette. use context7
```

--------------------------------

### Install Project Dependencies with npm

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/daisyui-astro-tailwind-documentation-template/+page.md

This command installs all necessary packages listed in the project's `package.json` file. It should be executed in the root directory of the downloaded template to prepare the environment for development.

```bash
npm install
```

--------------------------------

### Create a new Astro project using npm

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/astro/+page.md

This command initializes a new Astro project in the current directory. It sets up the basic project structure, allowing you to start developing with Astro.

```sh
npm create astro@latest ./
```

--------------------------------

### Configure npm scripts for Electron and Tailwind CSS

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/electron/+page.md

These commands add 'start' and 'build:css' scripts to the 'package.json' file. The 'start' script runs the Electron application, and the 'build:css' script compiles Tailwind CSS from 'src/input.css' to 'public/output.css'.

```sh
npm pkg set scripts.start="electron ."
npm pkg set scripts.build:css="tailwindcss -i src/input.css -o public/output.css"
```

--------------------------------

### Start Zola development server

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/zola/+page.md

This command starts the Zola development server, which serves the Zola project locally. It allows real-time preview of the website and automatically reloads the browser upon content or template changes.

```sh
zola serve
```

--------------------------------

### Run Astro Development Server

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/how-to-make-a-blog-quickly-using-astro-and-daisyUI/+page.md

This command starts the local development server for the Astro blog, allowing you to preview changes in real-time in your browser.

```bash
npm run dev
```

--------------------------------

### Initialize Angular Project and CLI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/angular/+page.md

This snippet outlines the initial steps to set up an Angular development environment, including global installation of the Angular CLI and creation of a new Angular project with CSS styling.

```sh
npm install -g @angular/cli@latest
```

```sh
ng new my-project --style css
cd my-project
```

--------------------------------

### Install and Configure Tailwind CSS and daisyUI in Angular

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/angular/+page.md

This section details the installation of necessary packages like daisyUI, Tailwind CSS, and PostCSS. It also covers the configuration of PostCSS for Tailwind and the integration of Tailwind and daisyUI into the main CSS file, followed by starting the Angular development server.

```sh
npm install daisyui@latest tailwindcss@latest @tailwindcss/postcss@latest postcss@latest --force
```

```json
{
  "plugins": {
    "@tailwindcss/postcss": {}
  }
}
```

```postcss
@import "tailwindcss";
@plugin "daisyui";
```

```sh
ng serve
```

--------------------------------

### Run Elysia Development Server

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/elysia/+page.md

Executes the development server for the Elysia application. This command starts the server, which in turn triggers the CSS build and watch processes, making the application accessible.

```sh
bun run dev
```

--------------------------------

### Create a new Elixir Phoenix project

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/phoenix/+page.md

This command creates a new Elixir Phoenix project in the current directory. The `--no-ecto` flag is used to skip the database setup, which is useful for demonstrations or projects not requiring a database.

```Shell
mix phx.new ./ --no-ecto
```

--------------------------------

### Configure Tailwind CSS plugin in Solid Start Vite

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/solid-start/+page.md

This JavaScript snippet modifies the `app.config.ts` file to integrate Tailwind CSS with Solid Start's Vite configuration. It imports `defineConfig` and `tailwindcss` and adds the Tailwind CSS plugin to the Vite plugins array.

```js
import { defineConfig } from "@solidjs/start/config";
import tailwindcss from "@tailwindcss/vite";
export default defineConfig({
  vite: {
    plugins: [tailwindcss()],
  },
});
```

--------------------------------

### Example Grok Prompt for daisyUI Theme Generation

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/editor/grok/+page.md

This example demonstrates how to use the daisyUI documentation URL within a Grok Deep Search prompt to request a specific daisyUI theme. It asks Grok to generate a light daisyUI 5 theme with a tropical color palette, leveraging the provided documentation for accurate output.

```Grok Prompt
https://daisyui.com/llms.txt give me a light daisyUI 5 theme with tropical color palette
```

--------------------------------

### Initialize a new Node.js project for Electron

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/electron/+page.md

This command sequence creates a new directory named 'myapp', navigates into it, and initializes a Node.js project, setting up the basic 'package.json' file. The entry point should be 'main.js'.

```sh
mkdir myapp
cd myapp
npm init
```

--------------------------------

### Usage Example: Prompt without explicit MCP server

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/editor/cline/+page.md

This example shows a prompt for generating daisyUI code. If a default or previously configured MCP server (like the GitMCP for daisyUI) is active, Cline will use it automatically without needing an explicit 'use' command in the prompt.

```markdown
give me a light daisyUI 5 theme with tropical color palette
```

--------------------------------

### Create New Rails Project

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/rails/+page.md

Initializes a new Ruby on Rails project and navigates into the project directory. This is the first step in setting up the Rails environment.

```sh
rails new my-app
cd my-app
```

--------------------------------

### Build CSS and run the Electron project

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/electron/+page.md

These commands first execute the 'build:css' script to compile the Tailwind CSS and daisyUI styles into 'public/output.css'. Subsequently, the 'npm start' command launches the Electron application, which will now use the generated CSS.

```sh
npm run build:css
npm start
```

--------------------------------

### Create a new Solid.js project with degit

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/solid/+page.md

This command initializes a new Solid.js project in the current directory using `npx degit`, setting up a basic JavaScript template.

```sh:Terminal
npx degit solidjs/templates/js
```

--------------------------------

### Run the Elixir Phoenix project development server

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/phoenix/+page.md

This command starts the Elixir Phoenix development server. Once the server is running, you can access your application and begin using daisyUI class names in your project.

```Shell
mix phx.server
```

--------------------------------

### Execute Installation Commands for Mary UI in Existing Laravel Project

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/mary-ui/+page.md

This set of bash commands covers the essential steps for installing Mary UI and its frontend dependencies in an existing Laravel project, including Composer package installation, Yarn dependency management, Livewire layout generation, and starting the development server.

```bash
composer require robsontenorio/mary
yarn add -D tailwindcss daisyui@latest postcss autoprefixer && npx tailwindcss init -p
php artisan livewire:layout
yarn dev
```

--------------------------------

### Initialize daisyUI with Yarn, Bun, or npm create alias

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/npm-init-daisyui/+page.md

These commands provide alternative ways to initialize Tailwind CSS and daisyUI using different package managers or an npm alias, offering the same streamlined setup process.

```Shell
yarn create daisyui
```

```Shell
bun create daisyui
```

```Shell
npm create daisyui
```

--------------------------------

### Install daisyUI with npm

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/what-is-daisyui/+page.md

This command installs the latest version of daisyUI as a development dependency using npm. It's the initial step required to integrate daisyUI into your project, making its component classes available for use with Tailwind CSS.

```bash
npm i -D daisyui@latest
```

--------------------------------

### Create a new SvelteKit project using npx

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/sveltekit/+page.md

This command initializes a new SvelteKit project in the current directory. It uses `npx` to execute the `sv` command, which is part of the SvelteKit CLI. This is the first step to set up your SvelteKit development environment.

```sh
npx sv create ./
```

--------------------------------

### Prompt Cursor to use Context7 for daisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/editor/cursor/+page.md

An example prompt for Cursor's Agent Mode, instructing it to use the Context7 MCP server to generate daisyUI code with specific theme requirements.

```md:prompt
give me a light daisyUI 5 theme with tropical color palette. use context7
```

--------------------------------

### Create a new React project with Vite

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/react/+page.md

Initializes a new React project using Vite in the current directory, setting up the basic project structure.

```sh
npm create vite@latest ./ -- --template react
```

--------------------------------

### Run Development Server for Astro Template

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/daisyui-astro-tailwind-documentation-template/+page.md

This command starts the local development server for the Astro documentation template. It allows you to preview changes in real-time in your browser, facilitating rapid development and testing.

```bash
npm run dev
```

--------------------------------

### Usage: Context7 with DaisyUI Prompt

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/editor/windsurf/+page.md

This example shows how to append a command to a prompt in Windsurf when using the Context7 MCP server. It instructs the AI to utilize the configured Context7 server for generating a daisyUI theme with specific aesthetic requirements.

```markdown
give me a light daisyUI 5 theme with tropical color palette. use context7
```

--------------------------------

### Install daisyUI via npm

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/pages/best-component-library-for-beginners/+page.md

This command line snippet shows how to install daisyUI as a development dependency using npm. This is the first step to integrate daisyUI into an existing Tailwind CSS project.

```bash
npm i -D daisyui
```

--------------------------------

### Run Django Development Server

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/django/+page.md

Starts the Django development server, making the application accessible locally. This command should be run in a separate terminal tab while Tailwind CSS is watching for changes.

```sh
python manage.py runserver
```

--------------------------------

### Project-Level Setup: Download daisyUI LLM Data

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/editor/cline/+page.md

This command downloads the daisyUI `llms.txt` file to a specified directory within your project (`.clinerules/daisyui.md`). This allows Cline to permanently reference the daisyUI documentation for code generation without needing to specify the URL in every prompt.

```sh
curl -L https://daisyui.com/llms.txt --create-dirs -o .clinerules/daisyui.md
```

--------------------------------

### Install Tailwind CSS and daisyUI packages

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/qwik/+page.md

Installs the necessary Tailwind CSS, Tailwind CSS Vite plugin, and daisyUI packages using npm.

```sh
npm install tailwindcss@latest @tailwindcss/vite@latest daisyui@latest
```

--------------------------------

### Setup Elysia Server with CSS Build and Watch

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/elysia/+page.md

Configures the Elysia server to automatically build Tailwind CSS on startup and watch for changes in the `public` directory to recompile CSS. It also sets up static file serving and gracefully handles process termination.

```ts
import { Elysia } from "elysia";
import { staticPlugin } from '@elysiajs/static'
import { exec } from 'child_process'
import { watch } from 'fs'

const buildCSS = () =>
  new Promise(resolve =>
    exec('tailwindcss -i ./src/app.css -o ./public/output.css',
      (_error, _stdout, stderr) => {
        console.log(stderr);
        resolve(null);
      })
  );

await buildCSS();

const watcher = watch('./public', { recursive: true },
  async () => {
    await buildCSS();
  }
);

process.on('SIGINT', () => {
  watcher.close();
  process.exit(0);
});

const app = new Elysia()
	.use(
		staticPlugin({
			assets: "public",
      prefix: "",
		}),
	)
	.listen(3000, ({ hostname, port }) => {
		console.log(`Server started http://${hostname}:${port}`);
	});
```

--------------------------------

### Run Development Server for Blog Preview

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/how-to-make-a-blog-quickly-using-astro-and-daisyUI/+page.md

This command initiates a local development server, enabling real-time preview of blog post changes. It's crucial for iterative development and ensuring content appears as expected before final deployment.

```bash
npm run dev
```

--------------------------------

### Create a New Elysia Project

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/elysia/+page.md

Initializes a new Elysia project using Bun and navigates into the newly created project directory. This command sets up the basic project structure.

```sh
bun create elysia myapp
cd myapp
```

--------------------------------

### Install Eleventy, PostCSS, Tailwind CSS, and daisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/11ty/+page.md

Installs core dependencies including Eleventy for static site generation, PostCSS for CSS transformations, Tailwind CSS and its typography plugin for utility-first styling, and daisyUI for pre-built components.

```sh
npm install @11ty/eleventy postcss tailwindcss@latest @tailwindcss/postcss@latest @tailwindcss/typography@latest daisyui@latest
```

--------------------------------

### Create Django Project and Navigate

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/django/+page.md

Initializes a new Django project named 'myapp' and then changes the current directory into the newly created project folder, preparing for further configuration.

```sh
django-admin startproject myapp
cd myapp
```

--------------------------------

### Create a new Deno Fresh project

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/fresh/+page.md

Initializes a new Deno Fresh project named 'myapp' without Tailwind CSS or VS Code integration, then navigates into the newly created project directory. This command requires Deno to be installed.

```sh
deno run -A -r https://fresh.deno.dev myapp --tailwind=false --vscode=false
cd myapp
```

--------------------------------

### Multi-line Code Mockup

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/mockup-code/+page.md

Shows a multi-line code mockup with different prefixes and text colors, simulating a command, installation progress, and completion messages. Both the multi-line output and its HTML source are provided.

```Shell
npm i daisyui
installing...
Done!
```

```HTML
<div class="$$mockup-code w-full">
  <pre data-prefix="$"><code>npm i daisyui</code></pre>
  <pre data-prefix=">" class="text-warning"><code>installing...</code></pre>
  <pre data-prefix=">" class="text-success"><code>Done!</code></pre>
</div>
```

--------------------------------

### Start Laravel Development Server

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/laravel/+page.md

Launches the built-in PHP development server for the Laravel application. This command makes the application accessible via a local URL (typically http://127.0.0.1:8000), allowing developers to view and interact with their project in a web browser.

```sh
php artisan serve
```

--------------------------------

### Install Tailwind CSS and daisyUI for Solid.js

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/solid/+page.md

Installs the required npm packages: `tailwindcss`, `@tailwindcss/vite` (for Vite integration), and `daisyui` to enable styling in the Solid.js project.

```sh:Terminal
npm install tailwindcss@latest @tailwindcss/vite@latest daisyui@latest
```

--------------------------------

### Create a Markdown homepage for Eleventy

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/11ty/+page.md

Sets up the main Markdown content file for the homepage, applying the default layout. It demonstrates basic Markdown headings and includes a daisyUI button within a 'not-prose' container to prevent Tailwind Typography from styling it.

```markdown
---
layout: layouts/default.njk
---

# Markdown heading 1

## Markdown heading 2

### Markdown heading 3

<div class="not-prose">
  <button class="btn">daisyUI Button</button>
</div>
```

--------------------------------

### Create a new Rsbuild project

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/rsbuild/+page.md

Initialize a new Rsbuild project in the current directory using the Rsbuild CLI.

```sh
npm create rsbuild -d ./
```

--------------------------------

### Create a new Vike project

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/vike/+page.md

Initialize a new Vike project in the current directory using the npm create command. This sets up the basic project structure for Vike.

```sh
npm create vike ./
```

--------------------------------

### Initialize a new Zola project

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/zola/+page.md

This command initializes a new Zola site named 'myblog' and then navigates into the newly created project directory, preparing it for further configuration.

```sh
zola init myblog
cd myblog
```

--------------------------------

### Create a New Laravel Project

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/laravel/+page.md

Initializes a new Laravel application named 'my-app' using the Laravel installer and then navigates into the newly created project directory. This is the foundational step before adding front-end dependencies.

```sh
laravel new my-app
cd my-app
```

--------------------------------

### ChatGPT Prompt to Load daisyUI Context

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/editor/chatgpt/+page.md

This prompt instructs ChatGPT to load the `daisyui.com/llms.txt` file as a contextual resource. This is used in conjunction with ChatGPT's `Search` feature to provide the AI with up-to-date daisyUI documentation for generating relevant code.

```Markdown
https://daisyui.com/llms.txt
```

--------------------------------

### Install Elysia Static Plugin

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/elysia/+page.md

Installs the `@elysiajs/static` plugin, which is essential for serving static assets like CSS and HTML files from the Elysia application.

```sh
bun install @elysiajs/static
```

--------------------------------

### Create a new Nuxt project

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/nuxt/+page.md

Initializes a new Nuxt.js project in the current directory using the `npx nuxi` command.

```sh
npx nuxi@latest init
```

--------------------------------

### Create new Vite project for Lit

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/lit/+page.md

Initializes a new Vite project in the current directory using the Lit template, setting up the basic project structure.

```sh
npm create vite@latest ./ -- --template lit
```

--------------------------------

### Example: Enabling All daisyUI Themes

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/config/+page.md

Shows how to configure the daisyUI plugin to enable all available themes.

```postcss
@plugin "daisyui" {
  themes: all;
}
```

--------------------------------

### Prompting Zed AI with Context7 for daisyUI Themes

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/editor/zed/+page.md

This example demonstrates how to formulate a prompt for the Zed AI agent to generate a daisyUI theme, specifically requesting a light theme with a tropical color palette. The `use context7` directive at the end ensures the AI leverages the configured Context7 MCP server for better context.

```md:prompt
give me a light daisyUI 5 theme with tropical color palette. use context7
```

--------------------------------

### Create and navigate into a new Waku project

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/waku/+page.md

This command initializes a new Waku project named 'myapp' using the latest Waku CLI and then changes the current directory to the newly created project folder. This is the first step to set up the development environment.

```sh
npm create waku@latest -- --project-name=myapp
cd myapp
```

--------------------------------

### Run Next.js development server

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/install-daisyui-and-tailwindcss-in-nextjs/+page.md

This command starts the Next.js development server, which typically becomes accessible at `http://localhost:3000/`. It compiles your project and enables features like hot-reloading for efficient development.

```bash
npm run dev
```

--------------------------------

### Download daisyUI llms.txt

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/editor/cursor/+page.md

Downloads the compact daisyUI documentation file to your project for use with Cursor. This command ensures the AI has access to the latest daisyUI information for code generation.

```sh
curl -L https://daisyui.com/llms.txt --create-dirs -o .cursor/rules/daisyui.mdc
```

--------------------------------

### Quick Use: DaisyUI LLM Docs in Windsurf

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/editor/windsurf/+page.md

This snippet shows the command to use within Windsurf's chat window to load the daisyUI LLM documentation file. This allows the AI to reference daisyUI's structure and components directly from the provided URL.

```markdown
@web https://daisyui.com/llms.txt
```

--------------------------------

### Initialize a new Bun project

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/bun/+page.md

This command initializes a new Bun project in the current directory using the default template. The `-y` flag automatically answers yes to prompts, streamlining the setup process.

```sh
bun init -y
```

--------------------------------

### Run Vite Development Server

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/laravel/+page.md

Starts the Vite development server, which is responsible for compiling and serving front-end assets (like CSS and JavaScript) for the Laravel application. This command typically watches for file changes and provides hot module replacement for a faster development workflow.

```sh
npm run dev
```

--------------------------------

### Create a new Next.js project

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/nextjs/+page.md

Initializes a new Next.js application in the current directory using the `npm create next-app` command. This sets up the basic project structure.

```sh
npm create next-app@latest ./
```

--------------------------------

### Install Django via pip

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/django/+page.md

Installs the Django framework using Python's package installer, pip, ensuring it's available for project creation.

```sh
python -m pip install Django
```

--------------------------------

### Build Blog for Production Deployment

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/how-to-make-a-blog-quickly-using-astro-and-daisyUI/+page.md

This command processes and optimizes all static assets of your blog, preparing them for a production environment. The output is a highly optimized, deployable version of your site.

```bash
npm run build
```

--------------------------------

### Install UnoCSS, daisyUI, and preset-daisy

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/unocss/+page.md

This command installs the core UnoCSS library, the daisyUI component library, and the unofficial `@ameinhardt/unocss-preset-daisy` package. These dependencies are required for styling and component integration.

```Terminal
npm install unocss daisyui @ameinhardt/unocss-preset-daisy
```

--------------------------------

### Create a new Next.js project

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/install-daisyui-and-tailwindcss-in-nextjs/+page.md

This command initializes a new Next.js application using the latest version of `create-next-app`. It prompts the user for configuration options, including enabling Tailwind CSS during the setup process.

```bash
npx create-next-app@latest
```

--------------------------------

### Install Tailwind CSS, PostCSS, Autoprefixer, and daisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/how-to-install-sveltekit-and-daisyui/+page.md

Installs necessary CSS processing tools and the daisyUI component library as development dependencies. It then initializes Tailwind CSS, generating `tailwind.config.js` and `postcss.config.js` files.

```shell
npm install -D tailwindcss postcss autoprefixer daisyui
npx tailwindcss init -p
```

--------------------------------

### Integrate daisyUI and TailwindCSS via CDN

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/cdn/+page.md

This HTML snippet provides the essential <link> and <script> tags required to include daisyUI and TailwindCSS directly from a CDN. Place these tags within the <head> section of your HTML document to enable the frameworks without local installation, allowing for quick setup of UI components and utility classes.

```HTML
<link href="https://cdn.jsdelivr.net/npm/daisyui@5" rel="stylesheet" type="text/css" />
<script src="https://cdn.jsdelivr.net/npm/@tailwindcss/browser@4"></script>
```

--------------------------------

### Initialize Node.js project and configure npm scripts

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/11ty/+page.md

Initializes a new Node.js project with default settings and adds 'dev' and 'build' scripts to package.json for serving Eleventy in development and building for production.

```sh
npm init -y
npm pkg set scripts.dev="eleventy --serve"
npm pkg set scripts.build="eleventy"
```

--------------------------------

### Create a Basic Dropdown Menu with Headless UI React

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/how-to-use-headless-ui-and-daisyui/+page.md

An example demonstrating how to create a simple dropdown menu component using Headless UI's `Menu`, `Menu.Button`, and `Menu.Item` components in React. This snippet shows the basic structural setup for an interactive dropdown without any styling applied.

```jsx
import { Menu } from "@headlessui/react"

export default function MyDropDown() {
  return (
    <Menu>
      <Menu.Button>Button</Menu.Button>
      <Menu.Items>
        <Menu.Item>
          <li>
            <a href="/link">Item 1</a>
          </li>
        </Menu.Item>
        <Menu.Item>
          <li>
            <a href="/link">Item 2</a>
          </li>
        </Menu.Item>
      </Menu.Items>
    </Menu>
  )
}
```

--------------------------------

### HTML Example: Stacking Card Components

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/stack/+page.md

Shows how to stack multiple DaisyUI card components using the `stack` class. This example demonstrates the default bottom alignment for layered elements, where subsequent cards appear on top of previous ones.

```html
<div class="$$stack size-28">
  <div class="border-base-content $$card bg-base-100 border text-center">
    <div class="$$card-body">A</div>
  </div>
  <div class="border-base-content $$card bg-base-100 border text-center">
    <div class="$$card-body">B</div>
  </div>
  <div class="border-base-content $$card bg-base-100 border text-center">
    <div class="$$card-body">C</div>
  </div>
</div>
```

--------------------------------

### HTML Examples for DaisyUI Swap Component

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/swap/+page.md

Demonstrates how to implement the DaisyUI Swap component in HTML, showing examples for swapping text content and SVG icons based on a checkbox state.

```HTML
<label class="$$swap">
  <input type="checkbox" />
  <div class="$$swap-on">ON</div>
  <div class="$$swap-off">OFF</div>
</label>
```

```HTML
<label class="$$swap">
  <!-- this hidden checkbox controls the state -->
  <input type="checkbox" />

  <!-- volume on icon -->
  <svg
    class="$$swap-on fill-current"
    xmlns="http://www.w3.org/2000/svg"
    width="48"
    height="48"
    viewBox="0 0 24 24">
    <path
      d="M14,3.23V5.29C16.89,6.15 19,8.83 19,12C19,15.17 16.89,17.84 14,18.7V20.77C18,19.86 21,16.28 21,12C21,7.72 18,4.14 14,3.23M16.5,12C16.5,10.23 15.5,8.71 14,7.97V16C15.5,15.29 16.5,13.76 16.5,12M3,9V15H7L12,20V4L7,9H3Z" />
  </svg>

  <!-- volume off icon -->
  <svg
    class="$$swap-off fill-current"
    xmlns="http://www.w3.org/2000/svg"
    width="48"
    height="48"
    viewBox="0 0 24 24">
    <path
      d="M3,9H7L12,4V20L7,15H3V9M16.59,12L14,9.41L15.41,8L18,10.59L20.59,8L22,9.41L19.41,12L22,14.59L20.59,16L18,13.41L15.41,16L14,14.59L16.59,12Z" />
  </svg>
</label>
```

--------------------------------

### Build Documentation Site for Production

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/daisyui-astro-tailwind-documentation-template/+page.md

This bash command compiles and optimizes the Astro documentation site for production deployment. Executing this command generates static assets ready for hosting.

```bash
npm run build
```

--------------------------------

### Configure PostCSS for Tailwind CSS

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/postcss/+page.md

Creates a PostCSS configuration file (`postcss.config.mjs`) to integrate Tailwind CSS as a PostCSS plugin. This setup allows PostCSS to process Tailwind CSS directives and generate the utility classes.

```js
const config = {
  plugins: {
    '@tailwindcss/postcss': {},
  },
};
export default config;
```

--------------------------------

### Install Headless UI for Vue or React

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/how-to-use-headless-ui-and-daisyui/+page.md

Commands to install Headless UI for Vue.js or React applications using npm. Choose the appropriate command based on your framework to add the library to your project dependencies.

```bash
npm install @headlessui/vue
```

```bash
npm install @headlessui/react
```

--------------------------------

### Migrate DaisyUI Button/Input Group to Join

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/upgrade/+page.md

This example shows the migration from deprecated DaisyUI `btn-group` and `input-group` classes to the new `join` class. The `join` class is used to group related elements like buttons, with individual items using `join-item` for proper styling and alignment.

```html
<div class="btn-group">
  <button class="btn">Button 1</button>
  <button class="btn">Button 2</button>
</div>
```

```html
<div class="join">
  <button class="btn join-item">Button 1</button>
  <button class="btn join-item">Button 2</button>
</div>
```

--------------------------------

### Install Tailwind CSS and daisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/elysia/+page.md

Installs the necessary packages for Tailwind CSS, its command-line interface, and the daisyUI component library. These are core dependencies for styling the application.

```sh
bun install tailwindcss@latest @tailwindcss/cli@latest daisyui@latest
```

--------------------------------

### Install Electron, Tailwind CSS, and daisyUI dependencies

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/electron/+page.md

This command installs the core Electron framework, the latest versions of Tailwind CSS and its CLI, and the daisyUI component library as project dependencies, making them available for use in the application.

```sh
npm install electron tailwindcss@latest @tailwindcss/cli@latest daisyui@latest
```

--------------------------------

### Install Tailwind CSS and daisyUI dependencies

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/react/+page.md

Installs the latest versions of Tailwind CSS, its Vite plugin, and daisyUI as project dependencies required for styling.

```sh
npm install tailwindcss@latest @tailwindcss/vite@latest daisyui@latest
```

--------------------------------

### Install Tailwind CSS and daisyUI dependencies

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/fresh/+page.md

Installs `tailwindcss`, `daisyui`, and `fresh-plugin-tailwindcss` as development dependencies using Deno's `npm:` and `jsr:` specifiers. This command fetches the latest versions of these packages required for styling and Fresh integration.

```sh
deno i -D npm:tailwindcss@latest npm:daisyui@latest jsr:@pakornv/fresh-plugin-tailwindcss
```

--------------------------------

### Install PostCSS, Tailwind CSS, and daisyUI via npm

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/postcss/+page.md

Installs the necessary npm packages for PostCSS, Tailwind CSS, and daisyUI, along with the PostCSS CLI for command-line usage. This command sets up the core dependencies for the project.

```sh
npm i postcss postcss-cli tailwindcss @tailwindcss/postcss daisyui@latest
```

--------------------------------

### Mockup Code with Line Prefix

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/mockup-code/+page.md

Demonstrates a single-line code mockup with a custom prefix, simulating a terminal command. The example includes both the rendered output and the underlying HTML structure.

```Shell
npm i daisyui
```

```HTML
<div class="$$mockup-code w-full">
  <pre data-prefix="$"><code>npm i daisyui</code></pre>
</div>
```

--------------------------------

### Install Tailwind CSS and daisyUI via npm

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/lit/+page.md

Installs the latest versions of Tailwind CSS, its Vite plugin (`@tailwindcss/vite`), and daisyUI as project dependencies using npm.

```sh
npm install tailwindcss@latest @tailwindcss/vite@latest daisyui@latest
```

--------------------------------

### Install Bun plugin for Tailwind CSS and daisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/bun/+page.md

This command installs `bun-plugin-tailwind` for integrating Tailwind CSS with Bun, and `daisyui` for UI components. Using `@latest` ensures the most recent stable version of daisyUI is installed.

```sh
bun install bun-plugin-tailwind daisyui@latest
```

--------------------------------

### Aligning Chat Bubbles with chat-start and chat-end

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/chat/+page.md

This example demonstrates how to align chat bubbles to the start or end of the container using the `chat-start` and `chat-end` utility classes. These classes control the horizontal positioning of individual chat messages within a conversation flow.

```HTML
<div class="$$chat $$chat-start">
  <div class="$$chat-bubble">
    It's over Anakin,
    <br />
    I have the high ground.
  </div>
</div>
<div class="$$chat $$chat-end">
  <div class="$$chat-bubble">You underestimate my power!</div>
</div>
```

--------------------------------

### Create Electron main process file (main.js)

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/electron/+page.md

This JavaScript code defines the main Electron process. It imports necessary modules, creates a browser window when the app is ready, and loads 'src/index.html' into that window, serving as the entry point for the Electron application.

```js
const { app, BrowserWindow } = require('electron')

const createWindow = () => {
  const win = new BrowserWindow()
  win.loadFile('src/index.html')
}

app.whenReady().then(() => {
  createWindow()
})
```

--------------------------------

### Create Rails Controller for Homepage

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/rails/+page.md

Defines a simple controller action for the homepage in a Rails application.

```rb
class PagesController < ApplicationController
  def home
  end
end
```

--------------------------------

### Install daisyUI npm package

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/waku/+page.md

This command installs the daisyUI library as a dependency in your Waku project. It fetches the package from the npm registry and adds it to your project's node_modules directory, making its components and styles available for use.

```sh
npm i daisyui
```

--------------------------------

### Import Tailwind CSS and daisyUI into main CSS

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/qwik/+page.md

Adds `@import` and `@plugin` directives to the main CSS file to include Tailwind CSS base styles and daisyUI components.

```postcss
@import "tailwindcss";
@plugin "daisyui";
```

--------------------------------

### Install daisyUI via npm

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/9-best-tailwind-css-plugins-for-developers/+page.md

This command installs the daisyUI package, a component library for Tailwind CSS, into your project's `node_modules` directory. It's the first step to integrating daisyUI into your development workflow.

```Shell
npm i daisyui
```

--------------------------------

### Install Tailwind CSS and daisyUI with npm

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/sveltekit/+page.md

This command installs the necessary packages for Tailwind CSS and daisyUI into your SvelteKit project. It includes `tailwindcss`, `@tailwindcss/vite` (for Vite integration), and `daisyui`. These are added as development dependencies to your project.

```sh
npm install tailwindcss@latest @tailwindcss/vite@latest daisyui@latest
```

--------------------------------

### Import Tailwind CSS and daisyUI into project CSS

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/solid/+page.md

Adds `@import "tailwindcss";` and `@plugin "daisyui";` directives to the main CSS file (e.g., `src/index.css`) to integrate the frameworks.

```postcss:src/index.css
@import "tailwindcss";
@plugin "daisyui";
```

--------------------------------

### Configure Astro for Tailwind CSS integration

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/astro/+page.md

This JavaScript configuration file (`astro.config.mjs`) integrates Tailwind CSS into your Astro build process. It uses the `@tailwindcss/vite` plugin to enable Tailwind CSS processing within Astro's Vite setup.

```js
// @ts-check
import { defineConfig } from "astro/config";
import tailwindcss from "@tailwindcss/vite";

export default defineConfig({
  vite: {
    plugins: [tailwindcss()],
  },
});
```

--------------------------------

### Migrate DaisyUI Form Control to Fieldset/Legend

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/upgrade/+page.md

This example illustrates the migration from deprecated DaisyUI form classes like `form-control` and `label-text` to the new `fieldset` and `legend` elements. This change improves semantic structure and accessibility for form inputs, replacing a `label` wrapper with a `fieldset`.

```html
<label class="form-control w-full max-w-xs">
  Login
  <div class="label">
    <span class="label-text">Name</span>
  </div>
  <input class="input" placeholder="Name" />
</label>
```

```html
<fieldset class="fieldset">
  <legend>Login</legend>
  <label class="label" for="name">Name</label>
  <input id="name" class="input" placeholder="Name" />
</fieldset>
```

--------------------------------

### HTML Example: Stacking Three Div Elements

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/stack/+page.md

Demonstrates how to use the `stack` class in HTML to layer three `div` elements on top of each other. The example sets a fixed width and height for the stack container, ensuring all layered items conform to the specified dimensions.

```html
<div class="$$stack h-20 w-32">
  <div class="bg-primary text-primary-content grid place-content-center rounded-box">1</div>
  <div class="bg-accent text-accent-content grid place-content-center rounded-box">2</div>
  <div class="bg-secondary text-secondary-content grid place-content-center rounded-box">
    3
  </div>
</div>
```

--------------------------------

### Install Tailwind CSS and daisyUI packages

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/nuxt/+page.md

Installs the latest versions of Tailwind CSS, `@tailwindcss/vite`, and daisyUI npm packages into the Nuxt project's dependencies.

```sh
npm install tailwindcss@latest @tailwindcss/vite@latest daisyui@latest
```

--------------------------------

### Install daisyUI via npm (Node Dependency)

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/rails/+page.md

Installs daisyUI as a Node.js dependency using npm. This method is recommended if Node.js is already part of the project workflow.

```sh
npm init -y
npm install daisyui@latest
```

--------------------------------

### Create a new Vite project using npm

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/vite/+page.md

Initializes a new Vite project in the current directory using the vanilla template. This command sets up the basic project structure required for a web application.

```sh
npm create vite@latest ./ -- --template vanilla
```

--------------------------------

### Install Tailwind CSS and daisyUI packages

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/nextjs/+page.md

Installs the required npm packages for Tailwind CSS (`tailwindcss`, `@tailwindcss/postcss`) and daisyUI (`daisyui`) into your Next.js project. These packages are essential for styling.

```sh
npm install tailwindcss @tailwindcss/postcss daisyui@latest
```

--------------------------------

### Fetch daisyUI Documentation for AI in Zed Chat

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/editor/zed/+page.md

These commands instruct the Zed AI agent to fetch the daisyUI documentation from `daisyui.com/llms.txt` and use it as context for generating accurate daisyUI code. The `@fetch` command is for general Thread chat, while `/fetch` is for Text thread chat.

```md:prompt
@fetch https://daisyui.com/llms.txt
```

```md:prompt
/fetch https://daisyui.com/llms.txt
```

--------------------------------

### Download daisyUI JavaScript Files

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/django/+page.md

Downloads the latest bundled JavaScript files for daisyUI (core and theme) into the `myapp/static/css/` directory, placing them alongside the Tailwind CSS executable.

```sh
curl -sLo myapp/static/css/daisyui.js https://github.com/saadeghi/daisyui/releases/latest/download/daisyui.js
curl -sLo myapp/static/css/daisyui-theme.js https://github.com/saadeghi/daisyui/releases/latest/download/daisyui-theme.js
```

--------------------------------

### Prompt Cursor to use daisyUI docs (Quick Use)

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/editor/cursor/+page.md

A quick method to instruct Cursor to use the daisyUI documentation from a web URL within the chat interface. This is useful for immediate context retrieval.

```md:prompt
@web https://daisyui.com/llms.txt
```

--------------------------------

### Install Tailwind CSS Gem for Rails

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/rails/+page.md

Adds the tailwindcss-rails gem to the project's Gemfile and executes the Rails generator to install Tailwind CSS.

```sh
./bin/bundle add tailwindcss-rails
./bin/rails tailwindcss:install
```

--------------------------------

### Basic JavaScript Function Example

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/layout-and-typography/+page.md

A simple JavaScript function `greet` that logs 'Hello, world!' to the console. This demonstrates a fundamental function definition and execution pattern in JavaScript.

```JavaScript
function greet() {
  console.log('Hello, world!');
}
```

--------------------------------

### Quick Use: Prompt for daisyUI LLM Data

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/editor/cline/+page.md

This method demonstrates how to instruct the Cline extension to use daisyUI's `llms.txt` file for generating code. By including the file URL at the beginning of your prompt, Cline will reference this data for more accurate results.

```markdown
https://daisyui.com/llms.txt
```

--------------------------------

### Create basic HTML structure for daisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/bun/+page.md

This HTML file sets up a basic webpage, links to `style.css` for styling, and includes a `daisyUI` button to demonstrate its integration. The viewport meta tag ensures responsiveness across devices.

```html
<!doctype html>
<html>
  <head>
    <title>daisyUI</title>
    <link rel="stylesheet" href="./style.css" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
  </head>
  <body>
    <button class="btn">daisyUI Button</button>
  </body>
</html>
```

--------------------------------

### Install Tailwind CSS and daisyUI with npm

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/astro/+page.md

This command installs the necessary packages for Tailwind CSS and daisyUI into your Astro project. It includes `tailwindcss`, `@tailwindcss/vite`, and `daisyui` as project dependencies.

```sh
npm install tailwindcss@latest @tailwindcss/vite@latest daisyui@latest
```

--------------------------------

### Clean up Next.js default global CSS

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/install-daisyui-and-tailwindcss-in-nextjs/+page.md

This CSS snippet shows the minimal content required in `app/globals.css` to ensure Tailwind CSS and its components (including daisyUI) are properly injected. It removes default Next.js styles for a cleaner starting point.

```css
@tailwind base;
@tailwind components;
@tailwind utilities;
```

--------------------------------

### Code Mockup Without Prefix

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/mockup-code/+page.md

Shows a simple code mockup without any line prefixes, displaying plain text. This example includes the rendered text and the minimal HTML required.

```Text
without prefix
```

```HTML
<div class="$$mockup-code w-full">
  <pre><code>without prefix</code></pre>
</div>
```

--------------------------------

### Create Electron renderer process HTML file (index.html)

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/electron/+page.md

This HTML file serves as the renderer process for the Electron application. It includes a Content Security Policy for security, links to the compiled CSS file ('../public/output.css'), and contains a simple button to demonstrate daisyUI components.

```html
<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="UTF-8">
    <!-- https://developer.mozilla.org/en-US/docs/Web/HTTP/CSP -->
    <meta http-equiv="Content-Security-Policy" content="default-src 'self'; script-src 'self'">
    <link rel="stylesheet" type="text/css" href="../public/output.css">
  </head>
  <body>
    <button class="btn">Hello daisyUI</button>
  </body>
</html>
```

--------------------------------

### Configure GitMCP Server for Workspace (Diff JSON)

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/editor/vscode/+page.md

This diff illustrates how to integrate the daisyUI GitMCP server into your VSCode workspace by modifying the mcp.json file. This setup allows Copilot to leverage the daisyUI GitMCP server for context-aware code generation.

```diff:.vscode/mcp.json
{
  "servers": {
+   "daisyUI": {
+     "type": "sse",
+     "url": "https://gitmcp.io/saadeghi/daisyui"
+   }
  }
}
```

--------------------------------

### Install daisyUI CSS Framework via npm

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/reactrouter/+page.md

Installs the latest version of the daisyUI CSS framework as a project dependency using npm. This command adds daisyUI to your `node_modules` and updates `package.json`.

```sh
npm install daisyui@latest
```

--------------------------------

### Configure Tailwind CSS to include daisyUI plugin

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/install-daisyui-and-tailwindcss-in-nextjs/+page.md

This TypeScript code snippet demonstrates how to modify the `tailwind.config.ts` file to integrate daisyUI. It imports the `daisyui` plugin and adds it to the `plugins` array, enabling daisyUI components and utilities within your Tailwind CSS setup.

```typescript
import type { Config } from 'tailwindcss'
import daisyui from 'daisyui'
const config: Config = {
  content: [
    './pages/**/*.{js,ts,jsx,tsx,mdx}',
    './components/**/*.{js,ts,jsx,tsx,mdx}',
    './app/**/*.{js,ts,jsx,tsx,mdx}',
  ],
  theme: {
    extend: {
      backgroundImage: {
        'gradient-radial': 'radial-gradient(var(--tw-gradient-stops))',
        'gradient-conic':
          'conic-gradient(from 180deg at 50% 50%, var(--tw-gradient-stops))',
      },
    },
  },
  plugins: [daisyui],
}
export default config
```

--------------------------------

### Install Tailwind CSS and daisyUI via npm

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/vite/+page.md

Installs the latest versions of Tailwind CSS, `@tailwindcss/vite`, and daisyUI packages as project dependencies using npm. These packages are essential for styling and UI components.

```sh
npm install tailwindcss@latest @tailwindcss/vite@latest daisyui@latest
```

--------------------------------

### Install Tailwind CSS and daisyUI packages

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/vike/+page.md

Install the latest versions of Tailwind CSS, its Vite plugin, and daisyUI using npm. These packages are essential for styling your Vike application.

```sh
npm install tailwindcss@latest @tailwindcss/vite@latest daisyui@latest
```

--------------------------------

### Example: Enabling Specific daisyUI Themes

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/config/+page.md

Demonstrates how to configure the daisyUI plugin to enable a custom set of themes, specifying default and dark mode themes.

```postcss
@plugin "daisyui" {
  themes: nord --default, abyss --prefersdark, cupcake, dracula;
}
```

--------------------------------

### Create Django Homepage Template

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/django/+page.md

Defines the basic HTML structure for the Django homepage in `myapp/templates/index.html`. It includes a link to the static CSS output file and a simple button styled with daisyUI classes.

```html
<!DOCTYPE html>
<html>
<head>
    <title>My Django App</title>
    {% load static %}
    <link href="{% static 'css/output.css' %}" rel="stylesheet" type="text/css" />
</head>
<body>
    <button class="btn btn-primary">Hello daisyUI</button>
</body>
</html>
```

--------------------------------

### Basic DaisyUI Footer Component HTML Example

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/footer/+page.md

An example of a basic footer component using DaisyUI classes. This snippet demonstrates how to structure a footer with multiple navigation columns (Services, Company, Legal) and applies responsive classes for horizontal layout on small screens and up, while defaulting to vertical.

```HTML
<footer class="$$footer sm:$$footer-horizontal bg-neutral text-neutral-content p-10">
  <nav>
    <h6 class="$$footer-title">Services</h6>
    <a class="$$link $$link-hover">Branding</a>
    <a class="$$link $$link-hover">Design</a>
    <a class="$$link $$link-hover">Marketing</a>
    <a class="$$link $$link-hover">Advertisement</a>
  </nav>
  <nav>
    <h6 class="$$footer-title">Company</h6>
    <a class="$$link $$link-hover">About us</a>
    <a class="$$link $$link-hover">Contact</a>
    <a class="$$link $$link-hover">Jobs</a>
    <a class="$$link $$link-hover">Press kit</a>
  </nav>
  <nav>
    <h6 class="$$footer-title">Legal</h6>
    <a class="$$link $$link-hover">Terms of use</a>
    <a class="$$link $$link-hover">Privacy policy</a>
    <a class="$$link $$link-hover">Cookie policy</a>
  </nav>
</footer>
```

--------------------------------

### Install Tailwind CSS CLI and daisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/cli/+page.md

Installs the latest versions of Tailwind CSS CLI and daisyUI using npm. This command should be run in a Node.js project directory after initializing it with `npm init -y`.

```sh
npm install tailwindcss@latest @tailwindcss/cli@latest daisyui@latest
```

--------------------------------

### Define Django Home View

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/django/+page.md

Creates a Python view function in `myapp/views.py` that handles requests for the homepage. This function renders the `index.html` template, serving it as the response.

```python
from django.shortcuts import render

def home(request):
    return render(request, 'index.html')
```

--------------------------------

### Render Button with daisyUI Classes

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/rails/+page.md

An ERB template demonstrating how to use daisyUI classes to style a button in a Rails view.

```erb
<button class="btn btn-primary">Hello daisyUI!</button>
```

--------------------------------

### Applying a daisyUI Theme

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/pages/best-component-library-for-beginners/+page.md

This HTML snippet illustrates how to apply a global theme to a website using daisyUI by setting the 'data-theme' attribute on the HTML tag. This simple method allows for quick visual changes across the entire site, demonstrating daisyUI's theming capabilities.

```html
<html data-theme="light">
  <!-- Your website content goes here -->
</html>
```

--------------------------------

### Code Mockup with Custom Colors

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/mockup-code/+page.md

Illustrates how to apply custom background and text colors to the code mockup container using utility classes. The example shows the colored text and the HTML with applied classes.

```Text
can be any color!
```

```HTML
<div class="$$mockup-code bg-primary text-primary-content w-full">
  <pre><code>can be any color!</code></pre>
</div>
```

--------------------------------

### Install daisyUI via npm

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/laravel/+page.md

Installs the latest version of the daisyUI library as a development dependency in the current project. This command uses npm, the Node.js package manager, to fetch and add daisyUI to the project's `node_modules`.

```sh
npm i -D daisyui@latest
```

--------------------------------

### Define Editor and LLM List in Svelte

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/editor/+page.md

This Svelte script defines an array of code editors and large language models (LLMs) with their names and slugs. This list is used to dynamically render links to documentation pages for each tool on the page, facilitating navigation to specific editor setups.

```Svelte
  import Translate from "$components/Translate.svelte"
  
const editors = [
  { name: "VSCode", slug: "vscode" },
  { name: "Cursor", slug: "cursor" },
  { name: "Zed", slug: "zed" },
  { name: "Windsurf", slug: "windsurf" },
  { name: "Claude Desktop", slug: "claude" },
  { name: "ChatGPT", slug: "chatgpt" },
  { name: "Gemini", slug: "gemini" },
  { name: "Grok", slug: "grok" },
  { name: "Cline – VSCode", slug: "cline" },
]
```

--------------------------------

### Create new Vite project

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/unocss/+page.md

This command initializes a new Vite project in the current directory using the vanilla JavaScript template. It sets up the basic project structure for a web application.

```Terminal
npm create vite@latest ./ -- --template vanilla
```

--------------------------------

### Install daisyUI 5 Alpha via npm

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/daisyui-5-alpha/+page.md

This command installs the alpha version of daisyUI 5 as a development dependency using npm. It's required for integrating daisyUI with Tailwind CSS 4 alpha.

```npm
npm i -D daisyui@alpha
```

--------------------------------

### Example: Adding a Prefix to daisyUI Classes

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/config/+page.md

Illustrates how to add a custom prefix to all daisyUI utility classes, preventing naming conflicts and aiding in project-specific styling.

```postcss
@plugin "daisyui" {
  prefix: "d-";
}
```

--------------------------------

### Example: Including Specific daisyUI Components

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/config/+page.md

Illustrates how to configure daisyUI to only include styles for a specified list of components, excluding all others.

```postcss
@plugin "daisyui" {
  include: button, input, select;
}
```

--------------------------------

### Usage: GitMCP with DaisyUI Prompt

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/editor/windsurf/+page.md

This markdown snippet shows a typical prompt for Windsurf when using the daisyUI GitMCP server. It requests a specific daisyUI theme without explicitly mentioning the server, as it's assumed to be configured and active.

```markdown
give me a light daisyUI 5 theme with tropical color palette
```

--------------------------------

### Create a new Vue project with Vite

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/vue/+page.md

Initializes a new Vue.js project using Vite in the current directory. This command sets up the basic project structure and dependencies for a Vue application.

```sh
npm create vite@latest ./ -- --template vue
```

--------------------------------

### Install Tailwind CSS and daisyUI dependencies

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/vue/+page.md

Installs the latest versions of Tailwind CSS, its Vite plugin, and daisyUI as project dependencies. These packages are essential for integrating the styling frameworks into the Vue application.

```sh
npm install tailwindcss@latest @tailwindcss/vite@latest daisyui@latest
```

--------------------------------

### Install daisyUI via Bundle File

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/rails/+page.md

Downloads the latest daisyUI JavaScript files directly into the Rails asset pipeline. This method is suitable for projects not using Node.js.

```sh
curl -sLo app/assets/tailwind/daisyui.js https://github.com/saadeghi/daisyui/releases/latest/download/daisyui.js
curl -sLo app/assets/tailwind/daisyui-theme.js https://github.com/saadeghi/daisyui/releases/latest/download/daisyui-theme.js
```

--------------------------------

### Configure Grok Deep Search with daisyUI Docs URL

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/editor/grok/+page.md

This prompt configures Grok's Deep Search feature to use the daisyUI documentation available at `daisyui.com/llms.txt` as a reference. This allows Grok to generate accurate daisyUI code based on subsequent prompts by providing the necessary context.

```Grok Prompt
https://daisyui.com/llms.txt
```

--------------------------------

### Display daisyUI Guides Image

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/daisyui-logo/+page.md

Displays an image related to daisyUI guides or documentation, centered on the page with horizontal margin. The image is styled to be full width, maintain aspect ratio, prevent pointer events, align to the bottom, and has rounded corners. It also uses `loading='lazy'` for performance.

```HTML
<div class="text-center mx-2">
  <img
    class="pointer-events-none w-full h-auto inline-block align-bottom rounded-box"
    src="https://img.daisyui.com/images/daisyui/guides.svg"
    alt="daisyUI logo"
    width="400"
    height="400"
    loading="lazy"
  />
</div>
```

--------------------------------

### Highlighted Line in Code Mockup

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/mockup-code/+page.md

Illustrates a multi-line code mockup where a specific line is highlighted with a warning background and text, indicating an error. This example includes the rendered output and the corresponding HTML.

```Shell
npm i daisyui
installing...
Error!
```

```HTML
<div class="$$mockup-code w-full">
  <pre data-prefix="1"><code>npm i daisyui</code></pre>
  <pre data-prefix="2"><code>installing...</code></pre>
  <pre data-prefix="3" class="bg-warning text-warning-content"><code>Error!</code></pre>
</div>
```

--------------------------------

### Install Tailwind CSS and daisyUI via npm

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/htmx/+page.md

Installs the latest versions of Tailwind CSS, its CLI, and daisyUI as Node.js dependencies using npm. This command should be run in your project's root directory.

```sh
npm install tailwindcss@latest @tailwindcss/cli@latest daisyui@latest
```

--------------------------------

### Install Tailwind CSS and daisyUI dependencies

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/rsbuild/+page.md

Add Tailwind CSS, its PostCSS plugin, and daisyUI as dependencies to your Rsbuild project using npm. Rsbuild has built-in support for PostCSS.

```sh
npm add tailwindcss @tailwindcss/postcss daisyui@latest
```

--------------------------------

### Import Tailwind CSS and daisyUI in SvelteKit CSS

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/sveltekit/+page.md

This PostCSS snippet, typically placed in `src/app.css`, imports the core Tailwind CSS utilities and the daisyUI plugin. It replaces any old styles to ensure a clean integration. This file serves as the main entry point for your application's global styles.

```postcss
@import "tailwindcss";
@plugin "daisyui";
```

--------------------------------

### Example: Excluding Multiple daisyUI Components

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/config/+page.md

Shows how to exclude multiple daisyUI components or styles, allowing for selective opt-out or integration with other libraries.

```postcss
@plugin "daisyui" {
  exclude: checkbox, footer, typography, glass, rootcolor, rootscrollgutter;
}
```

--------------------------------

### Install daisyUI as a development dependency

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/install-daisyui-and-tailwindcss-in-nextjs/+page.md

This command installs the latest version of the daisyUI component library as a development dependency using npm. The `-D` flag ensures it's added to the `devDependencies` section in your `package.json` file.

```bash
npm i -D daisyui@latest
```

--------------------------------

### Configure Rails Routes for Homepage

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/rails/+page.md

Sets the root path of the Rails application to the `home` action of the `PagesController`.

```rb
Rails.application.routes.draw do
  root to: 'pages#home'
end
```

--------------------------------

### DaisyUI Responsive Footer with Copyright and Social Icons

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/footer/+page.md

This HTML snippet demonstrates a responsive footer component using DaisyUI classes. It includes a copyright notice with a dynamically updated year and social media icons for Twitter, YouTube, and Facebook. The first example uses specific DaisyUI utility classes directly and buttons for social links, while the second example shows a more templated approach with `$$footer` placeholders and uses anchor tags for social icons.

```HTML
<footer class="items-center p-4 footer sm:footer-horizontal bg-neutral text-neutral-content rounded">
  <aside class="items-center grid-flow-col">
    <svg width="36" height="36" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg" fill-rule="evenodd" clip-rule="evenodd" class="fill-current"><path d="M22.672 15.226l-2.432.811.841 2.515c.33 1.019-.209 2.127-1.23 2.456-1.15.325-2.148-.321-2.463-1.226l-.84-2.518-5.013 1.677.84 2.517c.391 1.203-.434 2.542-1.831 2.542-.88 0-1.601-.564-1.86-1.314l-.842-2.516-2.431.809c-1.135.328-2.145-.317-2.463-1.229-.329-1.018.211-2.127 1.231-2.456l2.432-.809-1.621-4.823-2.432.808c-1.355.384-2.558-.59-2.558-1.839 0-.817.509-1.582 1.327-1.846l2.433-.809-.842-2.515c-.33-1.02.211-2.129 1.232-2.458 1.02-.329 2.13.209 2.461 1.229l.842 2.515 5.011-1.677-.839-2.517c-.403-1.238.484-2.553 1.843-2.553.819 0 1.585.509 1.85 1.326l.841 2.517 2.431-.81c1.02-.33 2.131.211 2.461 1.229.332 1.018-.21 2.126-1.23 2.456l-2.433.809 1.622 4.823 2.433-.809c1.242-.401 2.557.484 2.557 1.838 0 .819-.51 1.583-1.328 1.847m-8.992-6.428l-5.01 1.675 1.619 4.828 5.011-1.674-1.62-4.829z"></path></svg>
    <p>Copyright © {new Date().getFullYear()} - All right reserved</p>
  </aside>
  <nav class="grid-flow-col gap-4 md:place-self-center md:justify-self-end">
    <button><svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" class="fill-current"><path d="M24 4.557c-.883.392-1.832.656-2.828.775 1.017-.609 1.798-1.574 2.165-2.724-.951.564-2.005.974-3.127 1.195-.897-.957-2.178-1.555-3.594-1.555-3.179 0-5.515 2.966-4.797 6.045-4.091-.205-7.719-2.165-10.148-5.144-1.29 2.213-.669 5.108 1.523 6.574-.806-.026-1.566-.247-2.229-.616-.054 2.281 1.581 4.415 3.949 4.89-.693.188-1.452.232-2.224.084.626 1.956 2.444 3.379 4.6 3.419-2.07 1.623-4.678 2.348-7.29 2.04 2.179 1.397 4.768 2.212 7.548 2.212 9.142 0 14.307-7.721 13.995-14.646.962-.695 1.797-1.562 2.457-2.549z"></path></svg>
    </button>
    <button><svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" class="fill-current"><path d="M19.615 3.184c-3.604-.246-11.631-.245-15.23 0-3.897.266-4.356 2.62-4.385 8.816.029 6.185.484 8.549 4.385 8.816 3.6.245 11.626.246 15.23 0 3.897-.266 4.356-2.62 4.385-8.816-.029-6.185-.484-8.549-4.385-8.816zm-10.615 12.816v-8l8 3.993-8 4.007z"></path></svg></button>
    <button><svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" class="fill-current"><path d="M9 8h-3v4h3v12h5v-12h3.642l.358-4h-4v-1.667c0-.955.192-1.333 1.115-1.333h2.885v-5h-3.808c-3.596 0-5.192 1.583-5.192 4.615v3.385z"></path></svg></button>
  </nav>
</footer>
```

```HTML
<footer class="$$footer sm:$$footer-horizontal bg-neutral text-neutral-content items-center p-4">
  <aside class="grid-flow-col items-center">
    <svg
      width="36"
      height="36"
      viewBox="0 0 24 24"
      xmlns="http://www.w3.org/2000/svg"
      fill-rule="evenodd"
      clip-rule="evenodd"
      class="fill-current">
      <path
        d="M22.672 15.226l-2.432.811.841 2.515c.33 1.019-.209 2.127-1.23 2.456-1.15.325-2.148-.321-2.463-1.226l-.84-2.518-5.013 1.677.84 2.517c.391 1.203-.434 2.542-1.831 2.542-.88 0-1.601-.564-1.86-1.314l-.842-2.516-2.431.809c-1.135.328-2.145-.317-2.463-1.229-.329-1.018.211-2.127 1.231-2.456l2.432-.809-1.621-4.823-2.432.808c-1.355.384-2.558-.59-2.558-1.839 0-.817.509-1.582 1.327-1.846l2.433-.809-.842-2.515c-.33-1.02.211-2.129 1.232-2.458 1.02-.329 2.13.209 2.461 1.229l.842 2.515 5.011-1.677-.839-2.517c-.403-1.238.484-2.553 1.843-2.553.819 0 1.585.509 1.85 1.326l.841 2.517 2.431-.81c1.02-.33 2.131.211 2.461 1.229.332 1.018-.21 2.126-1.23 2.456l-2.433.809 1.622 4.823 2.433-.809c1.242-.401 2.557.484 2.557 1.838 0 .819-.51 1.583-1.328 1.847m-8.992-6.428l-5.01 1.675 1.619 4.828 5.011-1.674-1.62-4.829z"></path>
    </svg>
    <p>Copyright © {new Date().getFullYear()} - All right reserved</p>
  </aside>
  <nav class="grid-flow-col gap-4 md:place-self-center md:justify-self-end">
    <a>
      <svg
        xmlns="http://www.w3.org/2000/svg"
        width="24"
        height="24"
        viewBox="0 0 24 24"
        class="fill-current">
        <path
          d="M24 4.557c-.883.392-1.832.656-2.828.775 1.017-.609 1.798-1.574 2.165-2.724-.951.564-2.005.974-3.127 1.195-.897-.957-2.178-1.555-3.594-1.555-3.179 0-5.515 2.966-4.797 6.045-4.091-.205-7.719-2.165-10.148-5.144-1.29 2.213-.669 5.108 1.523 6.574-.806-.026-1.566-.247-2.229-.616-.054 2.281 1.581 4.415 3.949 4.89-.693.188-1.452.232-2.224.084.626 1.956 2.444 3.379 4.6 3.419-2.07 1.623-4.678 2.348-7.29 2.04 2.179 1.397 4.768 2.212 7.548 2.212 9.142 0 14.307-7.721 13.995-14.646.962-.695 1.797-1.562 2.457-2.549z"></path>
      </svg>
    </a>
    <a>
      <svg
        xmlns="http://www.w3.org/2000/svg"
        width="24"
        height="24"
        viewBox="0 0 24 24"
        class="fill-current">
        <path
```

--------------------------------

### Configure Vite for Tailwind CSS in Qwik

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/qwik/+page.md

Modifies the Vite configuration file to include the Tailwind CSS plugin, integrating it into the Qwik build process.

```js
import tailwindcss from "@tailwindcss/vite";
//...
export default defineConfig(({ command, mode }): UserConfig => {
  return {
    plugins: [tailwindcss(), qwikCity(), qwikVite(), tsconfigPaths()],
    // ...
  };
});
```

--------------------------------

### Example: Setting a Single Default daisyUI Theme

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/config/+page.md

Demonstrates how to configure daisyUI to use a single theme as the default, making it the only available theme unless custom themes are added.

```postcss
@plugin "daisyui" {
  themes: dracula --default;
}
```

--------------------------------

### Create React Router Project with npm

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/reactrouter/+page.md

Initializes a new React Router project in the current directory using `npm create`. This command sets up the basic project structure and dependencies required for a React Router application.

```sh
npm create react-router@latest ./
```

--------------------------------

### Add Context7 MCP Server to Zed Editor

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/editor/zed/+page.md

This configuration adds the Context7 MCP server to Zed, enabling enhanced AI communication for daisyUI-related queries. It involves specifying a name for the server and the command to execute the server process, using `npx` to run the `@upstash/context7-mcp` package.

```sh
context7
```

```sh
npx -y @upstash/context7-mcp@latest
```

--------------------------------

### Create a default Eleventy layout template

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/11ty/+page.md

Defines a Nunjucks layout template for Eleventy, providing a basic HTML structure, meta tags, a dynamic title, and linking to the main CSS file. The 'prose' class from Tailwind Typography is applied to the body.

```html
---
title: My Blog
---

<!doctype html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>{{ title }}</title>
    <link rel="stylesheet" href="/styles/index.css">
  </head>
  <body class="prose">
    {{ content | safe }}
  </body>
</html>
```

--------------------------------

### Example: Disabling All daisyUI Themes

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/config/+page.md

Illustrates how to disable all default daisyUI themes, useful when adding custom themes separately.

```postcss
@plugin "daisyui" {
  themes: false;
}
```

--------------------------------

### Import Tailwind CSS and daisyUI in PostCSS

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/lit/+page.md

Adds `@import` rules for Tailwind CSS and `@plugin` for daisyUI into the main CSS file (`src/index.css`), integrating them into the project's stylesheet for processing by PostCSS.

```postcss
@import "tailwindcss";
@plugin "daisyui";
```

--------------------------------

### Configure Vite for Tailwind CSS and Solid.js plugins

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/solid/+page.md

Modifies `vite.config.js` to include `tailwindcss()` and `solidPlugin()` in the plugins array. It also sets the development server port and build target.

```js:vite.config.js
import { defineConfig } from "vite";
import tailwindcss from "@tailwindcss/vite";
import solidPlugin from "vite-plugin-solid";

export default defineConfig({
  plugins: [tailwindcss(), solidPlugin()],
  server: {
    port: 3000,
  },
  build: {
    target: "esnext",
  },
});
```

--------------------------------

### Create main PostCSS input file

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/11ty/+page.md

Defines the primary CSS file that imports Tailwind CSS, the Tailwind CSS Typography plugin, and daisyUI. This file serves as the entry point for PostCSS to process and generate the final stylesheet.

```postcss
@import 'tailwindcss';
@plugin "@tailwindcss/typography";
@plugin "daisyui";
```

--------------------------------

### Example content for Tailwind CSS safelist.txt

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/most-common-mistake-when-using-tailwind-css/+page.md

Provides an example of a simple text file (`safelist.txt`) containing Tailwind CSS class names, one per line, to be used with the `content` configuration for safelisting.

```text
bg-red-500
bg-green-500
bg-blue-500
```

--------------------------------

### HTML Example: Stacking Multiple Images

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/stack/+page.md

Illustrates the use of the `stack` class to layer multiple image elements, creating a visual stack of photos. Each image is given a `rounded-box` class for styling, and the container has a specified width.

```html
<div class="$$stack w-48">
  <img src="https://img.daisyui.com/images/stock/photo-1572635148818-ef6fd45eb394.webp" class="rounded-box" />
  <img src="https://img.daisyui.com/images/stock/photo-1565098772267-60af42b81ef2.webp" class="rounded-box" />
  <img src="https://img.daisyui.com/images/stock/photo-1559703248-dcaaec9fab78.webp" class="rounded-box" />
</div>
```

--------------------------------

### Basic Markdown Structure for Documentation

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/daisyui-astro-tailwind-documentation-template/+page.md

This Markdown snippet illustrates the basic frontmatter and content structure for a new documentation page in an Astro project. It includes metadata like title and description, and demonstrates embedding Svelte components and using standard Markdown for content organization.

```markdown
---
title: Getting Started
description: "Quasi sapiente voluptates aut minima non doloribus similique quisquam. In quo expedita ipsum nostrum corrupti incidind. Et aut eligendi ea perferendis."
---

<script>
  import Translate from "$components/Translate.svelte"
</script>

## Overview

Authentication is a crucial aspect of any web application, ensuring that users are who they claim to be before granting access to resources or sensitive information. Access Shield simplifies the process of user authentication, offering features such as:

- **User Registration and Login**: Allow users to create accounts and securely log in to your application.
- **Password Hashing and Encryption**: Safeguard user passwords by securely hashing and encrypting them before storage.
- **Session Management**: Manage user sessions to maintain authentication state across requests.
- **OAuth Integration**: Simplify user authentication by integrating with popular OAuth providers.
- **Two-Factor Authentication (2FA)**: Enhance security by requiring an additional authentication factor.
- **Role-Based Access Control (RBAC)**: Define roles and permissions to control access to resources.
```

--------------------------------

### Tailwind CSS 4 Integration with daisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/v5/+page.md

Demonstrates the integration of daisyUI with Tailwind CSS 4. The 'Before' example shows the traditional method of requiring daisyUI as a plugin in tailwind.config.js. The 'After' example illustrates the new approach using the @plugin directive directly in the CSS file, leveraging Tailwind CSS 4's updated plugin API.

```javascript
module.exports = {
  content: ["./src/**/*.{html,js}"],
  plugins: [
    require('daisyui');
  ],
}
```

```postcss
@import "tailwindcss";
@plugin "daisyui";
```

--------------------------------

### Register Django App in Settings

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/django/+page.md

Adds the 'myapp' application to the `INSTALLED_APPS` list in `myapp/settings.py`. This step is crucial for Django to discover and use the application's components, including its views and templates.

```python
INSTALLED_APPS = [
    "django.contrib.admin",
    "django.contrib.auth",
    "django.contrib.contenttypes",
    "django.contrib.sessions",
    "django.contrib.messages",
    "django.contrib.staticfiles",
    "myapp",
]
```

--------------------------------

### Import Tailwind CSS and daisyUI in main CSS file

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/rsbuild/+page.md

Add `@import` rules for Tailwind CSS and `@plugin` for daisyUI to your main CSS file (e.g., `src/App.css`). This integrates their styles and components into your project.

```postcss
@import "tailwindcss";
@plugin "daisyui";
```

--------------------------------

### DaisyUI Extra Small Dock Component Example

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/dock/+page.md

An example HTML structure for a DaisyUI dock component, demonstrating the `dock-xs` size modifier. It includes three buttons, with one marked as active, and uses embedded SVG icons for visual representation. This snippet shows a concrete implementation within a larger context.

```HTML
<div class="dock dock-xs relative border border-base-300">
    <button>
      <svg class="size-[1.2em]" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24"><g fill="currentColor" stroke-linejoin="miter" stroke-linecap="butt"><polyline points="1 11 12 2 23 11" fill="none" stroke="currentColor" stroke-miterlimit="10" stroke-width="2"></polyline><path d="m5,13v7c0,1.105.895,2,2,2h10c1.105,0,2-.895,2-2v-7" fill="none" stroke="currentColor" stroke-linecap="square" stroke-miterlimit="10" stroke-width="2"></path><line x1="12" y1="22" x2="12" y2="18" fill="none" stroke="currentColor" stroke-linecap="square" stroke-miterlimit="10" stroke-width="2"></line></g></svg>
    </button>
    <button class="dock-active">
      <svg class="size-[1.2em]" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24"><g fill="currentColor" stroke-linejoin="miter" stroke-linecap="butt"><polyline points="3 14 9 14 9 17 15 17 15 14 21 14" fill="none" stroke="currentColor" stroke-miterlimit="10" stroke-width="2"></polyline><rect x="3" y="3" width="18" height="18" rx="2" ry="2" fill="none" stroke="currentColor" stroke-linecap="square" stroke-miterlimit="10" stroke-width="2"></rect></g></svg>
    </button>
    <button>
      <svg class="size-[1.2em]" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24"><g fill="currentColor" stroke-linejoin="miter" stroke-linecap="butt"><circle cx="12" cy="12" r="3" fill="none" stroke="currentColor" stroke-linecap="square" stroke-miterlimit="10" stroke-width="2"></circle><path d="m22,13.25v-2.5l-2.318-.966c-.167-.581-.395-1.135-.682-1.654l.954-2.318-1.768-1.768-2.318.954c-.518-.287-1.073-.515-1.654-.682l-.966-2.318h-2.5l-.966,2.318c-.581.167-1.135.395-1.654.682l-2.318-.954-1.768,1.768.954,2.318c-.287.518-.515,1.073-.682,1.654l-2.318.966v2.5l2.318.966c.167.581.395,1.135.682,1.654l-.954,2.318,1.768,1.768,2.318-.954c.518.287,1.073.515,1.654.682l.966,2.318h2.5l.966-2.318c.581-.167,1.135-.395,1.654-.682l2.318.954,1.768-1.768-.954-2.318c.287-.518.515-1.073.682-1.654l2.318-.966Z" fill="none" stroke="currentColor" stroke-linecap="square" stroke-miterlimit="10" stroke-width="2"></path></g></svg>
    </button>
  </div>
```

--------------------------------

### Create Tailwind CSS input file (input.css)

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/electron/+page.md

This PostCSS file acts as the entry point for Tailwind CSS. It imports the core Tailwind CSS framework and registers the daisyUI plugin, allowing Tailwind to process and generate the final CSS output including daisyUI styles.

```postcss
@import "tailwindcss";
@plugin "daisyui";
```

--------------------------------

### Import Tailwind CSS and daisyUI into PostCSS

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/fresh/+page.md

Adds `@import "tailwindcss";` and `@plugin "daisyui";` directives to the `static/styles.css` file. These lines instruct PostCSS to include Tailwind's utility classes and daisyUI's component styles in the final CSS bundle.

```postcss
@import "tailwindcss";
@plugin "daisyui";
```

--------------------------------

### Define Astro Homepage Layout and Components

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/how-to-make-a-blog-quickly-using-astro-and-daisyUI/+page.md

This Astro component code from `src/pages/index.astro` defines the main structure of the blog's homepage. It imports and renders various components like `Hero`, `LatestBlogs`, `FeaturedPost`, `TopArticles`, and `NewsletterCard` within a `HomeLayout`.

```jsx
---
import Hero from "../components/Hero.astro";
import TopArticles from "../components/TopArticles.astro";
import LatestBlogs from "../components/RecentBlogs.astro";
import NewsletterCard from "../components/NewsletterCard.astro";
import FeaturedPost from "../components/FeaturedPost.astro";
import HomeLayout from "../layouts/HomeLayout.astro";
---

<script>
  import Translate from "$components/Translate.svelte"
</script>

<HomeLayout title="Home" description="Welcome to my blog">
  <div class="w-full">
    <Hero />
    <div class="px-5 xl:px-10">
      <LatestBlogs />
      <FeaturedPost />
      <TopArticles />
      <NewsletterCard />
    </div>
  </div>
</HomeLayout>
```

--------------------------------

### Reference daisyUI LLM data in Gemini prompt

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/editor/gemini/+page.md

Instructs Gemini to reference the daisyUI LLM data file by including its URL at the beginning of the prompt. This ensures Gemini has access to the condensed daisyUI documentation for accurate code generation.

```text
https://daisyui.com/llms.txt
```

--------------------------------

### Configure Context7 MCP Server for Workspace (Diff JSON)

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/editor/vscode/+page.md

This diff shows how to add the Context7 MCP server configuration to your VSCode workspace's mcp.json file. This enables Copilot to communicate with Context7 for improved AI results within the current project.

```diff:.vscode/mcp.json
{
  "servers": {
+   "context7": {
+     "type": "stdio",
+     "command": "npx",
+     "args": [
+       "-y",
+       "@upstash/context7-mcp@latest"
+     ]
+   }
  }
}
```

--------------------------------

### Render a full keyboard layout using DaisyUI Kbd

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/kbd/+page.md

Demonstrates how to arrange multiple `kbd` components within flexbox containers to simulate a full keyboard layout, useful for complex shortcut displays or interactive guides.

```html
<div class="my-1 flex w-full justify-center gap-1">
  <kbd class="$$kbd">q</kbd>
  <kbd class="$$kbd">w</kbd>
  <kbd class="$$kbd">e</kbd>
  <kbd class="$$kbd">r</kbd>
  <kbd class="$$kbd">t</kbd>
  <kbd class="$$kbd">y</kbd>
  <kbd class="$$kbd">u</kbd>
  <kbd class="$$kbd">i</kbd>
  <kbd class="$$kbd">o</kbd>
  <kbd class="$$kbd">p</kbd>
</div>
<div class="my-1 flex w-full justify-center gap-1">
  <kbd class="$$kbd">a</kbd>
  <kbd class="$$kbd">s</kbd>
  <kbd class="$$kbd">d</kbd>
  <kbd class="$$kbd">f</kbd>
  <kbd class="$$kbd">g</kbd>
  <kbd class="$$kbd">h</kbd>
  <kbd class="$$kbd">j</kbd>
  <kbd class="$$kbd">k</kbd>
  <kbd class="$$kbd">l</kbd>
</div>
<div class="my-1 flex w-full justify-center gap-1">
  <kbd class="$$kbd">z</kbd>
  <kbd class="$$kbd">x</kbd>
  <kbd class="$$kbd">c</kbd>
  <kbd class="$$kbd">v</kbd>
  <kbd class="$$kbd">b</kbd>
  <kbd class="$$kbd">n</kbd>
  <kbd class="$$kbd">m</kbd>
  <kbd class="$$kbd">/</kbd>
</div>
```

--------------------------------

### Download daisyUI bundled JavaScript files

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/zola/+page.md

These commands download the latest bundled JavaScript files for daisyUI, including the main daisyUI script and an optional theme script, placing them in the `static/` directory alongside the Tailwind CSS executable.

```sh
curl -sLo static/daisyui.js https://github.com/saadeghi/daisyui/releases/latest/download/daisyui.js
curl -sLo static/daisyui-theme.js https://github.com/saadeghi/daisyui/releases/latest/download/daisyui-theme.js
```

--------------------------------

### Save daisyUI llms.txt to Workspace (Shell Command)

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/editor/vscode/+page.md

This command downloads the daisyUI llms.txt file and saves it to a specified location in your project's workspace. This allows Copilot to use the file as a permanent instruction source for code generation.

```sh:Terminal
curl -L https://daisyui.com/llms.txt --create-dirs -o .github/daisyui.instructions.md
```

--------------------------------

### Make Tailwind CSS Executable

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/django/+page.md

Grants execute permissions to the downloaded Tailwind CSS CLI executable on Linux and macOS systems. This step is necessary to run the CLI tool.

```sh
chmod +x myapp/static/css/tailwindcss
```

--------------------------------

### Styling a Button with Custom CSS from Scratch

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/pages/best-component-library-for-beginners/+page.md

This CSS snippet demonstrates how to style a button completely from scratch, including various interactive states like hover, active, focus, and disabled. It illustrates the extensive amount of code required to define a single component's appearance and behavior, highlighting the time-consuming nature of this approach.

```css
.my-button {
  background-color: #4338ca;
  color: white;
  padding: 10px 16px;
  border-radius: 6px;
  font-weight: 600;
  font-size: 14px;
  box-shadow: 0 1px 3px rgba(0, 0, 0, 0.1);
  cursor: pointer;
  transition: all 0.2s ease;
  border: none;
  outline: none;
  position: relative;
  overflow: hidden;
  display: inline-flex;
  align-items: center;
  justify-content: center;
  text-decoration: none;
}
.my-button:hover {
  background-color: #3730a3;
  transform: translateY(-1px);
  box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
}
.my-button:active {
  background-color: #312e81;
  transform: translateY(0);
  box-shadow: 0 1px 2px rgba(0, 0, 0, 0.1);
}
.my-button:focus {
  outline: 2px solid #818cf8;
  outline-offset: 2px;
}
.my-button:disabled {
  background-color: #c7d2fe;
  color: #6366f1;
  cursor: not-allowed;
  box-shadow: none;
}
```

--------------------------------

### DaisyUI Vertical Timeline Example without Icons

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/timeline/+page.md

An HTML example showcasing a vertical timeline component using DaisyUI classes. This snippet demonstrates the structure for displaying chronological events with `timeline-start` and `timeline-end` boxes, suitable for simple timelines without explicit icons.

```html
<ul class="timeline timeline-vertical">
  <li>
    <div class="timeline-start timeline-box">First Macintosh computer</div>
    <hr/>
  </li>
  <li>
    <hr/>
    <div class="timeline-end timeline-box">iMac</div>
    <hr/>
  </li>
  <li>
    <hr/>
    <div class="timeline-start timeline-box">iPod</div>
    <hr/>
  </li>
  <li>
    <hr/>
    <div class="timeline-end timeline-box">iPhone</div>
    <hr/>
  </li>
  <li>
    <hr/>
    <div class="timeline-start timeline-box">Apple Watch</div>
  </li>
</ul>
```

--------------------------------

### Run Tailwind CSS official upgrade tool

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/upgrade/+page.md

Execute the official Tailwind CSS upgrade CLI tool to automatically apply the new Tailwind CSS changes to your project.

```bash
npx @tailwindcss/upgrade
```

--------------------------------

### Import Tailwind CSS and daisyUI into global CSS

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/nextjs/+page.md

Adds `@import` rules for Tailwind CSS and `@plugin` for daisyUI into your `app/globals.css` file. This integrates their styles into your application, making daisyUI components and Tailwind utilities available.

```postcss
@import "tailwindcss";
@plugin "daisyui";
```

--------------------------------

### Download Tailwind CSS standalone CLI executable

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/zola/+page.md

These commands download the latest version of the Tailwind CSS standalone CLI executable for various operating systems (Linux, macOS, Windows) and save it to the `static/` directory. Users should select the command appropriate for their specific OS and architecture.

```sh
# Run the corresponding command for your OS

# Linux
curl -sLo static/tailwindcss https://github.com/tailwindlabs/tailwindcss/releases/latest/download/tailwindcss-linux-arm64
curl -sLo static/tailwindcss https://github.com/tailwindlabs/tailwindcss/releases/latest/download/tailwindcss-linux-arm64-musl
curl -sLo static/tailwindcss https://github.com/tailwindlabs/tailwindcss/releases/latest/download/tailwindcss-linux-x64
curl -sLo static/tailwindcss https://github.com/tailwindlabs/tailwindcss/releases/latest/download/tailwindcss-linux-x64-musl

# MacOS
curl -sLo static/tailwindcss https://github.com/tailwindlabs/tailwindcss/releases/latest/download/tailwindcss-macos-arm64
curl -sLo static/tailwindcss https://github.com/tailwindlabs/tailwindcss/releases/latest/download/tailwindcss-macos-x64

# Windows
curl -sLo static\tailwindcss.exe https://github.com/tailwindlabs/tailwindcss/releases/latest/download/tailwindcss-windows-x64.exe
```

--------------------------------

### Using a UI Library Component

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/pages/best-component-library-for-beginners/+page.md

This snippet demonstrates how a component from a typical UI library might be imported and used in a React-like environment. It highlights the dependency on a specific library and its components, often leading to less portable markup and limited customization.

```js
import { Button } from "some-ui-library"

return <Button className="btn btn-primary">Click Me</Button>
```

--------------------------------

### Add a daisyUI button to a SvelteKit page

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/how-to-install-sveltekit-and-daisyui/+page.md

Modifies the `src/routes/+page.svelte` file to include a basic HTML button with daisyUI's primary button classes (`btn btn-primary`). This demonstrates the successful integration of daisyUI components.

```svelte
<h1>Welcome to SvelteKit</h1>
<p>Visit <a href="https://kit.svelte.dev">kit.svelte.dev</a> to read the documentation</p>
<button class="btn btn-primary">Hello daisyUI</button>
```

--------------------------------

### DaisyUI Responsive Navbar with Dropdown and Centered Logo

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/navbar/+page.md

This code snippet demonstrates how to construct a responsive navigation bar using DaisyUI. It includes a dropdown menu for navigation items, a centered brand or logo, and right-aligned action buttons (e.g., search, notifications). The provided examples showcase the HTML structure for this common UI component, with the second example highlighting DaisyUI class usage with '$$' prefixes.

```html
<div class="navbar bg-base-100 mb-40 shadow-sm">
  <div class="navbar-start">
    <div class="dropdown">
      <div tabindex="0" role="button" class="btn btn-ghost btn-circle">
        <svg xmlns="http://www.w3.org/2000/svg" class="h-5 w-5" fill="none" viewBox="0 0 24 24" stroke="currentColor"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 6h16M4 12h16M4 18h7" /></svg>
      </div>
      <ul tabindex="0" class="mt-3 z-1 p-2 shadow menu menu-sm dropdown-content bg-base-100 rounded-box w-52">
        <li><button>Homepage</button></li>
        <li><button>Portfolio</button></li>
        <li><button>About</button></li>
      </ul>
    </div>
  </div>
  <div class="navbar-center">
    <button class="btn btn-ghost text-xl">daisyUI</button>
  </div>
  <div class="navbar-end">
    <button class="btn btn-ghost btn-circle">
      <svg xmlns="http://www.w3.org/2000/svg" class="h-5 w-5" fill="none" viewBox="0 0 24 24" stroke="currentColor"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M21 21l-6-6m2-5a7 7 0 11-14 0 7 7 0 0114 0z" /></svg>
    </button>
    <button class="btn btn-ghost btn-circle">
      <div class="indicator">
        <svg xmlns="http://www.w3.org/2000/svg" class="h-5 w-5" fill="none" viewBox="0 0 24 24" stroke="currentColor"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 17h5l-1.405-1.405A2.032 2.032 0 0118 14.158V11a6.002 6.002 0 00-4-5.659V5a2 2 0 10-4 0v.341C7.67 6.165 6 8.388 6 11v3.159c0 .538-.214 1.055-.595 1.436L4 17h5m6 0v1a3 3 0 11-6 0v-1m6 0H9" /></svg>
        <span class="badge badge-xs badge-primary indicator-item"></span>
      </div>
    </button>
  </div>
</div>
```

```html
<div class="$$navbar bg-base-100 shadow-sm">
  <div class="$$navbar-start">
    <div class="$$dropdown">
      <div tabindex="0" role="button" class="$$btn $$btn-ghost $$btn-circle">
        <svg xmlns="http://www.w3.org/2000/svg" class="h-5 w-5" fill="none" viewBox="0 0 24 24" stroke="currentColor"> <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 6h16M4 12h16M4 18h7" /> </svg>
      </div>
      <ul
        tabindex="0"
        class="$$menu $$menu-sm $$dropdown-content bg-base-100 rounded-box z-1 mt-3 w-52 p-2 shadow">
        <li><a>Homepage</a></li>
        <li><a>Portfolio</a></li>
        <li><a>About</a></li>
      </ul>
    </div>
  </div>
  <div class="$$navbar-center">
    <a class="$$btn $$btn-ghost text-xl">daisyUI</a>
  </div>
  <div class="$$navbar-end">
    <button class="$$btn $$btn-ghost $$btn-circle">
      <svg xmlns="http://www.w3.org/2000/svg" class="h-5 w-5" fill="none" viewBox="0 0 24 24" stroke="currentColor"> <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2"
```

--------------------------------

### Basic Alert Component Example

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/alert/+page.md

Demonstrates a basic alert component with an SVG icon and text message. This is the default structure for an alert, providing a simple notification to the user.

```HTML
<div role="alert" class="$$alert">
  <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" class="stroke-info h-6 w-6 shrink-0">
    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M13 16h-1v-4h-1m1-4h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z"></path>
  </svg>
  <span>12 unread messages. Tap to see.</span>
</div>
```

--------------------------------

### Add CSS build script to package.json

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/postcss/+page.md

Adds a `build:css` script to `package.json` that uses PostCSS to compile `app.css` into `public/output.css`. This script automates the CSS build process, making it easy to generate the final stylesheet.

```json
{
  "scripts": {
    "build:css": "postcss app.css -o public/output.css"
  }
}
```

--------------------------------

### Example: Excluding a Specific daisyUI Component

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/config/+page.md

Demonstrates how to exclude a single daisyUI component or style, such as `rootscrollgutter`, from the build.

```postcss
@plugin "daisyui" {
  exclude: rootscrollgutter;
}
```

--------------------------------

### Toast Positioned Top-Start

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/toast/+page.md

Shows a toast component positioned at the top-start (top-left) of the page. This example includes multiple alert messages within the toast.

```html
<div class="toast toast-top toast-start">
  <div class="alert alert-info">
    <span>New mail arrived.</span>
  </div>
  <div class="alert alert-success">
    <span>Message sent successfully.</span>
  </div>
</div>
```

--------------------------------

### Configure daisyUI GitMCP Server in Cursor

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/editor/cursor/+page.md

Adds the daisyUI GitMCP server to Cursor's global configuration. This provides Cursor with direct access to daisyUI's specific AI model for generating code.

```json
{
  "mcpServers": {
    "daisyui Docs": {
      "url": "https://gitmcp.io/saadeghi/daisyui"
    }
  }
}
```

--------------------------------

### Create Tailwind CSS Input File

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/django/+page.md

Defines the `input.css` file in `myapp/static/css/`. This file imports Tailwind CSS, registers the daisyUI JavaScript file as a plugin, and specifies the Django templates directory as a source for Tailwind's content scanning.

```css
@import "tailwindcss" source(none);
@plugin "./daisyui.js";
@source "../../templates";
```

--------------------------------

### Make Tailwind CSS executable on Linux/MacOS

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/zola/+page.md

This command grants execute permissions to the downloaded Tailwind CSS binary on Unix-like systems (Linux and macOS), making it runnable from the terminal.

```sh
chmod +x static/tailwindcss
```

--------------------------------

### Create New Astro Blog Post File

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/how-to-make-a-blog-quickly-using-astro-and-daisyUI/+page.md

This command illustrates the directory path for creating a new blog post in the Astro template. New posts are added as `.mdx` files within the `src/content/posts` directory.

```bash
src/content/posts/my-new-post.mdx
```

--------------------------------

### Configure Eleventy to process CSS with PostCSS and Tailwind

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/11ty/+page.md

Sets up Eleventy to run PostCSS and Tailwind CSS before the build process. This configuration ensures that the CSS is compiled and available in the output directory, allowing Eleventy to use the generated styles.

```js
import fs from 'fs';
import path from 'path';
import postcss from 'postcss';
import tailwindcss from '@tailwindcss/postcss';

export default function (eleventyConfig) {
  eleventyConfig.on('eleventy.before', async () => {
    const tailwindInputPath = path.resolve('./src/styles/index.css');
    const tailwindOutputPath = './dist/styles/index.css';
    const cssContent = fs.readFileSync(tailwindInputPath, 'utf8');
    const outputDir = path.dirname(tailwindOutputPath);

    if (!fs.existsSync(outputDir)) {
      fs.mkdirSync(outputDir, { recursive: true });
    }

    const result = await postcss([tailwindcss()]).process(cssContent, {
      from: tailwindInputPath,
      to: tailwindOutputPath,
    });

    fs.writeFileSync(tailwindOutputPath, result.css);
  });

  return {
    dir: { input: 'src', output: 'dist' },
  };
}
```

--------------------------------

### Migrate Artboard classes to Tailwind CSS utilities

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/upgrade/+page.md

The `artboard` and `phone-*` classes have been removed. Replace them with equivalent Tailwind CSS `w-*` and `h-*` utility classes to set width and height.

```diff
- <div class="artboard phone-1">
+ <div class="w-[320px] h-[568px]}>
```

--------------------------------

### Run CSS build script

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/postcss/+page.md

Executes the `build:css` script defined in `package.json` to compile the PostCSS and Tailwind CSS directives into a final CSS file, `public/output.css`. This command generates the stylesheet ready for use in your web application.

```sh
npm run build:css
```

--------------------------------

### Example: Disabling daisyUI Logs

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/config/+page.md

Demonstrates how to disable console logs generated by daisyUI, useful for cleaning up console output in production or specific development environments.

```postcss
@plugin "daisyui" {
  logs: false;
}
```

--------------------------------

### Configure PostCSS for daisyUI (Bundle File)

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/rails/+page.md

Configures the PostCSS file to import Tailwind CSS and the local daisyUI plugin files. It also shows how to include custom themes.

```postcss
@import "tailwindcss" source(none);
@source "../../../public/*.html";
@source "../../../app/helpers/**/*.rb";
@source "../../../app/javascript/**/*.js";
@source "../../../app/views/**/*";

@plugin "./daisyui.js";

/* Optional for custom themes – Docs: https://daisyui.com/docs/themes/#how-to-add-a-new-custom-theme */
@plugin "./daisyui-theme.js"{
  /* custom theme here */
}
```

--------------------------------

### Basic Drawer Component HTML Structure

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/drawer/+page.md

Provides a complete HTML example for implementing a basic DaisyUI Drawer. This snippet demonstrates how to set up the toggle checkbox, the main content area, and the sidebar with its overlay, using DaisyUI's utility classes.

```HTML
<div class="$$drawer">
  <input id="my-drawer" type="checkbox" class="$$drawer-toggle" />
  <div class="$$drawer-content">
    <!-- Page content here -->
    <label for="my-drawer" class="$$btn $$btn-primary $$drawer-button">Open drawer</label>
  </div>
  <div class="$$drawer-side">
    <label for="my-drawer" aria-label="close sidebar" class="$$drawer-overlay"></label>
    <ul class="$$menu bg-base-200 text-base-content min-h-full w-80 p-4">
      <!-- Sidebar content here -->
      <li><a>Sidebar Item 1</a></li>
      <li><a>Sidebar Item 2</a></li>
    </ul>
  </div>
</div>
```

--------------------------------

### Download Tailwind CSS Executable

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/django/+page.md

Downloads the appropriate Tailwind CSS standalone CLI executable for various operating systems (Linux, macOS, Windows) into the `myapp/static/css/` directory. This allows running Tailwind CSS without Node.js.

```sh
# Run the corresponding command for your OS

# Linux
curl -sLo myapp/static/css/tailwindcss https://github.com/tailwindlabs/tailwindcss/releases/latest/download/tailwindcss-linux-arm64
curl -sLo myapp/static/css/tailwindcss https://github.com/tailwindlabs/tailwindcss/releases/latest/download/tailwindcss-linux-arm64-musl
curl -sLo myapp/static/css/tailwindcss https://github.com/tailwindlabs/tailwindcss/releases/latest/download/tailwindcss-linux-x64
curl -sLo myapp/static/css/tailwindcss https://github.com/tailwindlabs/tailwindcss/releases/latest/download/tailwindcss-linux-x64-musl

# MacOS
curl -sLo myapp/static/css/tailwindcss https://github.com/tailwindlabs/tailwindcss/releases/latest/download/tailwindcss-macos-arm64
curl -sLo myapp/static/css/tailwindcss https://github.com/tailwindlabs/tailwindcss/releases/latest/download/tailwindcss-macos-x64

# Windows
curl -sLo myapp\static\css\tailwindcss.exe https://github.com/tailwindlabs/tailwindcss/releases/latest/download/tailwindcss-windows-x64.exe
```

--------------------------------

### Add daisyUI to CSS file (with built-in themes)

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/upgrade/+page.md

Import Tailwind CSS and daisyUI into your main CSS file, enabling specific built-in themes directly within the `@plugin` directive.

```postcss
@import "tailwindcss";
@plugin "daisyui" {
  themes: light --default, dark --prefersdark, cupcake;
}
```

--------------------------------

### Configure PostCSS for daisyUI (Node Dependency)

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/rails/+page.md

Configures the PostCSS file to import Tailwind CSS and the daisyUI plugin. This ensures daisyUI classes are processed correctly.

```postcss
@import "tailwindcss" source(none);
@source "../../../public/*.html";
@source "../../../app/helpers/**/*.rb";
@source "../../../app/javascript/**/*.js";
@source "../../../app/views/**/*";

@plugin "daisyui";
```

--------------------------------

### Position a Tooltip at the Top in HTML

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/tooltip/+page.md

Demonstrates how to position the tooltip above the target element using the `tooltip-top` class. This example also forces the tooltip open for visibility.

```HTML
<div class="$$tooltip $$tooltip-open $$tooltip-top" data-tip="hello">
  <button class="$$btn">Top</button>
</div>
```

--------------------------------

### Styling a Button with Tailwind CSS Utility Classes

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/pages/best-component-library-for-beginners/+page.md

This HTML snippet demonstrates styling a button using a comprehensive set of Tailwind CSS utility classes. It includes styling for various states (hover, focus, active, disabled) and incorporates an SVG icon. A second example shows how to add a loading state with an animated spinner, illustrating the potential for long class lists and reduced HTML readability when using Tailwind CSS.

```html
<!-- Tailwind CSS example - a realistic button with all needed features -->
<button
  class="inline-flex w-auto items-center justify-center space-x-2 rounded-md bg-blue-600 px-4 py-2.5 text-sm font-medium text-white shadow-sm transition-colors duration-200 ease-in-out hover:bg-blue-700 focus:ring-2 focus:ring-blue-500 focus:ring-offset-2 focus:outline-none active:bg-blue-800 disabled:cursor-not-allowed disabled:bg-blue-400 disabled:opacity-50"
>
  <svg
    xmlns="http://www.w3.org/2000/svg"
    class="h-4 w-4"
    fill="none"
    viewBox="0 0 24 24"
    stroke="currentColor"
    stroke-width="2"
  >
    <path stroke-linecap="round" stroke-linejoin="round" d="M5 13l4 4L19 7" />
  </svg>
  <span>Click Me</span>
</button>

<!-- And what happens when you need to add a loading state? -->
<button
  class="inline-flex w-auto items-center justify-center space-x-2 rounded-md bg-blue-600 px-4 py-2.5 text-sm font-medium text-white shadow-sm transition-colors duration-200 ease-in-out hover:bg-blue-700 focus:ring-2 focus:ring-blue-500 focus:ring-offset-2 focus:outline-none active:bg-blue-800 disabled:cursor-not-allowed disabled:bg-blue-400 disabled:opacity-50"
>
  <svg
    class="mr-2 -ml-1 h-4 w-4 animate-spin text-white"
    xmlns="http://www.w3.org/2000/svg"
    fill="none"
    viewBox="0 0 24 24"
  >
    <circle
      class="opacity-25"
      cx="12"
      cy="12"
      r="10"
      stroke="currentColor"
      stroke-width="4"
    ></circle>
    <path
      class="opacity-75"
      fill="currentColor"
      d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"
    ></path>
  </svg>
  <span>Loading...</span>
</button>
```

--------------------------------

### Add daisyUI GitMCP Server Configuration for Claude

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/editor/claude/+page.md

This snippet demonstrates how to configure the daisyUI GitMCP server within Claude desktop's developer settings. By adding this entry to `claude_desktop_config.json`, Claude can communicate with the GitMCP server hosted at `gitmcp.io/saadeghi/daisyui`, improving its understanding and generation of daisyUI code.

```json
{
  "mcpServers": {
    "daisyui Docs": {
      "command": "npx",
      "args": [
        "mcp-remote",
        "https://gitmcp.io/saadeghi/daisyui"
      ]
    }
  }
}
```

--------------------------------

### Configure daisyUI GitMCP Server in Windsurf

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/editor/windsurf/+page.md

This JSON snippet illustrates how to configure the daisyUI GitMCP server within Windsurf's settings. It provides the URL for the GitMCP server, allowing Windsurf to connect and leverage its AI capabilities for daisyUI-related queries.

```json
{
  "mcpServers": {
    "daisyui Docs": {
      "serverUrl": "https://gitmcp.io/saadeghi/daisyui"
    }
  }
}
```

--------------------------------

### Integrate Pikaday in React

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/calendar/+page.md

Demonstrates how to install Pikaday and integrate it into a React functional component using `useEffect` and `useRef` hooks for initialization and proper cleanup.

```bash
npm i pikaday
```

```jsx
import { useEffect, useRef } from "react";
import Pikaday from "pikaday";

export default function App() {
  const myDatepicker = useRef(null);
  useEffect(() => {
    const picker = new Pikaday({
      field: myDatepicker.current
    });
    return () => picker.destroy();
  }, []);
  return (
    <input type="text" className="$$input $$pika-single" defaultValue="Pick a date" ref={myDatepicker} />
  );
}
```

--------------------------------

### Basic Stacked Cards with Content in DaisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/stack/+page.md

This example demonstrates a standard implementation of stacked cards with more detailed content. It shows how to structure information, including titles and paragraphs, within each card's body, providing a practical use case for displaying multiple related notifications or items in a stacked format.

```html
<div class="$$stack">
  <div class="$$card shadow-md bg-base-100">
    <div class="$$card-body">
      <h2 class="$$card-title">Notification 1</h2>
      <p>You have 3 unread messages. Tap here to see.</p>
    </div>
  </div>
  <div class="$$card shadow-md bg-base-100">
    <div class="$$card-body">
      <h2 class="$$card-title">Notification 2</h2>
      <p>You have 3 unread messages. Tap here to see.</p>
    </div>
  </div>
  <div class="$$card shadow-md bg-base-100">
    <div class="$$card-body">
      <h2 class="$$card-title">Notification 3</h2>
      <p>You have 3 unread messages. Tap here to see.</p>
    </div>
  </div>
</div>
```

--------------------------------

### Integrate Pikaday in Svelte

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/calendar/+page.md

Shows how to install Pikaday via npm and integrate it into a Svelte component using the `$effect` reactive primitive for lifecycle management and cleanup.

```bash
npm i pikaday
```

```svelte
<script>
  import Pikaday from "pikaday";
  let myDatepicker;
  $effect(() => {
    if (myDatepicker) {
      const picker = new Pikaday({
        field: myDatepicker
      });
      return () => picker.destroy();
    }
  });
</script>

<input type="text" class="$$input $$pika-single"  bind:this={myDatepicker} value="Pick a day" />
```

--------------------------------

### Position a Tooltip at the Bottom in HTML

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/tooltip/+page.md

Demonstrates how to position the tooltip below the target element using the `tooltip-bottom` class. This example also forces the tooltip open for visibility.

```HTML
<div class="$$tooltip $$tooltip-open $$tooltip-bottom" data-tip="hello">
  <button class="$$btn">Bottom</button>
</div>
```

--------------------------------

### HTML Example: Stacking Card Components with Top Alignment

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/stack/+page.md

Demonstrates stacking DaisyUI card components using both the `stack` and `stack-top` classes. This configuration aligns the layered elements to the top of the container, causing them to overlap from the top downwards.

```html
<div class="$$stack $$stack-top size-28">
  <div class="border-base-content $$card bg-base-100 border text-center">
    <div class="$$card-body">A</div>
  </div>
  <div class="border-base-content $$card bg-base-100 border text-center">
    <div class="$$card-body">B</div>
  </div>
  <div class="border-base-content $$card bg-base-100 border text-center">
    <div class="$$card-body">C</div>
  </div>
</div>
```

--------------------------------

### Link compiled CSS in HTML

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/postcss/+page.md

Includes the compiled CSS file (`output.css`) in an HTML document using a `<link>` tag. This makes the Tailwind CSS and daisyUI styles available to the web page, allowing you to use their utility classes.

```html
<link href="./output.css" rel="stylesheet">
```

--------------------------------

### Rename Avatar `online` class

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/upgrade/+page.md

The `online` class for avatars has been renamed to `avatar-online`. Update your HTML to reflect this change.

```diff
- <div class="avatar online">
+ <div class="avatar avatar-online">
  <div class="w-24 rounded-full">
    <img src="https://img.daisyui.com/images/stock/photo-1534528741775-53994a69daeb.webp" />
  </div>
</div>
```

--------------------------------

### Create a basic browser mockup with border

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/mockup-browser/+page.md

This HTML snippet demonstrates how to create a simple browser mockup using DaisyUI's `mockup-browser` component. It includes a visible border and a toolbar with an address bar, simulating a standard browser window.

```HTML
<div class="mockup-browser border border-base-300 w-full">
  <div class="mockup-browser-toolbar">
    <div class="input">https://daisyui.com</div>
  </div>
  <div class="grid place-content-center border-t border-base-300 h-80">Hello!</div>
</div>
```

--------------------------------

### Configure Social Media Links in Astro Hero Section

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/how-to-make-a-blog-quickly-using-astro-and-daisyUI/+page.md

This HTML snippet from `src/components/Hero.astro` demonstrates how to embed social media links within the hero section using daisyUI button styles. It includes an example for Twitter, showing the structure for adding other social platforms.

```html
<div class="flex justify-center lg:justify-start space-x-4 mt-4">
  <a
    class="btn btn-circle btn-md"
    href="https://www.x.com"
    aria-label="twitter"
  >
    <svg viewBox="0 0 24 24" aria-hidden="true" class="h-8 w-8">
      <path
        d="M13.3174 10.7749L19.1457 4H17.7646L12.7039 9.88256L8.66193 4H4L10.1122 12.8955L4 20H5.38119L10.7254 13.7878L14.994 20H19.656L13.3171 10.7749H13.3174ZM11.4257 12.9738L10.8064 12.0881L5.87886 5.03974H8.00029L11.9769 10.728L12.5962 11.6137L17.7652 19.0075H15.6438L11.4257 12.9742V12.9738Z"
        fill="currentColor"
      ></path>
    </svg>
  </a>
  <!-- other social links -->
</div>
```

--------------------------------

### Implement a Ghost style Textarea

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/textarea/+page.md

This example shows how to apply a 'ghost' style to the textarea, which typically removes its background, making it blend more with the surrounding content. It uses the `textarea-ghost` class.

```html
<textarea class="$$textarea $$textarea-ghost" placeholder="Bio"></textarea>
```

--------------------------------

### Import Tailwind CSS and daisyUI into your CSS

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/vike/+page.md

Add import statements for Tailwind CSS and daisyUI plugins to your main CSS file. This step integrates their styles and components into your project, making them available for use in your HTML.

```postcss
@import "tailwindcss";
@plugin "daisyui";
```

--------------------------------

### Import Tailwind CSS and daisyUI into main CSS file

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/react/+page.md

Adds the necessary `@import` and `@plugin` directives to the main CSS file (`src/App.css`) to integrate Tailwind CSS and daisyUI, making their utility classes and components available.

```postcss
@import "tailwindcss";
@plugin "daisyui";
```

--------------------------------

### Integrate Pikaday in Vue.js

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/calendar/+page.md

Illustrates how to install Pikaday and use it within a Vue component, initializing it in the `mounted` lifecycle hook and referencing the input element with `this.$refs`.

```bash
npm i pikaday
```

```vue
<script>
import Pikaday from "pikaday";
export default {
  mounted: function() {
    const picker = new Pikaday({
      field: this.$refs.myDatepicker
    });
  }
};
</script>
<template>
  <input type="text" class="$$input $$pika-single" ref="myDatepicker" value="Pick a day"/>
</template>
```

--------------------------------

### Configure Context7 MCP Server in Windsurf

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/editor/windsurf/+page.md

This JSON snippet demonstrates how to add a custom Context7 MCP server configuration to Windsurf. It specifies the command to execute for the server, enabling Windsurf to communicate with Context7 for AI model interactions.

```json
{
  "mcpServers": {
    "context7": {
      "command": "npx",
      "args": ["-y", "@upstash/context7-mcp@latest"]
    }
  }
}
```

--------------------------------

### Configure PostCSS for daisyUI (CDN)

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/rails/+page.md

Configures the PostCSS file to import Tailwind CSS and daisyUI directly from a CDN. This is the quickest way to add daisyUI without local files.

```postcss
@import "tailwindcss" source(none);
@source "../../../public/*.html";
@source "../../../app/helpers/**/*.rb";
@source "../../../app/javascript/**/*.js";
@source "../../../app/views/**/*";

@import "https://cdn.jsdelivr.net/npm/daisyui@5";
```

--------------------------------

### Add daisyUI to CSS file (basic import)

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/upgrade/+page.md

Import Tailwind CSS and daisyUI into your main CSS file using PostCSS `@import` and `@plugin` directives.

```postcss
@import "tailwindcss";
@plugin "daisyui";
```

--------------------------------

### Divider Text Placement

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/divider/+page.md

This example illustrates how to control the horizontal placement of text within a divider using `divider-start` and `divider-end` classes.

```HTML
<div class="flex w-full flex-col">
  <div class="$$divider $$divider-start">Start</div>
  <div class="$$divider">Default</div>
  <div class="$$divider $$divider-end">End</div>
</div>
```

--------------------------------

### Styling a Button with Bootstrap and Custom Overrides

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/pages/best-component-library-for-beginners/+page.md

This example shows a basic HTML button styled with Bootstrap's default classes. It then demonstrates how to override Bootstrap's default primary button styles using an embedded CSS block with `!important` rules. This highlights the difficulty and verbosity involved in customizing components when fighting against a framework's strong default styling.

```html
<!-- Bootstrap example -->
<button class="btn btn-primary">Click Me</button>

<!-- Want a custom style? Get ready for this: -->
<style>
  .btn-primary {
    --bs-btn-color: #fff;
    --bs-btn-bg: #6200ee !important; /* Have to use !important to override */
    --bs-btn-border-color: #6200ee !important;
    --bs-btn-hover-color: #fff;
    --bs-btn-hover-bg: #5000c7 !important;
    --bs-btn-hover-border-color: #4b00bd !important;
    --bs-btn-focus-shadow-rgb: 49, 132, 253;
    --bs-btn-active-color: #fff;
    --bs-btn-active-bg: #4b00bd !important;
    --bs-btn-active-border-color: #4700b3 !important;
    --bs-btn-active-shadow: inset 0 3px 5px rgba(0, 0, 0, 0.125);
    --bs-btn-disabled-color: #fff;
    --bs-btn-disabled-bg: #6200ee !important;
    --bs-btn-disabled-border-color: #6200ee !important;
  }
</style>
```

--------------------------------

### Implement DaisyUI Modal with showModal() Method

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/modal/+page.md

This snippet demonstrates how to create a responsive modal dialog using the HTML `<dialog>` element's `showModal()` method. It shows how to position the modal differently on small (`modal-bottom`) and medium (`sm:modal-middle`) screens, and includes both plain HTML and JSX examples for opening and closing the modal.

```HTML
<!-- Open the modal using ID.showModal() method -->
<button class="$$btn" onclick="my_modal_5.showModal()">open modal</button>
<dialog id="my_modal_5" class="$$modal $$modal-bottom sm:$$modal-middle">
  <div class="$$modal-box">
    <h3 class="text-lg font-bold">Hello!</h3>
    <p class="py-4">Press ESC key or click the button below to close</p>
    <div class="$$modal-action">
      <form method="dialog">
        <!-- if there is a button in form, it will close the modal -->
        <button class="$$btn">Close</button>
      </form>
    </div>
  </div>
</dialog>
```

```JSX
{/* Open the modal using document.getElementById('ID').showModal() method */}
<button className="$$btn" onClick={()=>document.getElementById('my_modal_5').showModal()}>open modal</button>
<dialog id="my_modal_5" className="$$modal $$modal-bottom sm:$$modal-middle">
  <div className="$$modal-box">
    <h3 className="font-bold text-lg">Hello!</h3>
    <p className="py-4">Press ESC key or click the button below to close</p>
    <div className="$$modal-action">
      <form method="dialog">
        {/* if there is a button in form, it will close the modal */}
        <button className="$$btn">Close</button>
      </form>
    </div>
  </div>
</dialog>
```

--------------------------------

### Theme Controller using a toggle with text

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/theme-controller/+page.md

Provides an example of a theme controller using a toggle input, accompanied by descriptive text labels. The `theme-controller` class on the checkbox enables theme switching.

```html
<label class="flex cursor-pointer gap-2">
  <span class="$$label-text">Current</span>
  <input type="checkbox" value="synthwave" class="$$toggle $$theme-controller" />
  <span class="$$label-text">Synthwave</span>
</label>
```

--------------------------------

### daisyUI Button Markup

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/pages/best-component-library-for-beginners/+page.md

This HTML snippet demonstrates the simplicity of creating a button using daisyUI. By applying the 'btn' class, daisyUI provides pre-defined styles, significantly reducing the amount of markup compared to raw Tailwind CSS.

```html
<button class="btn">Click Me</button>
```

--------------------------------

### Rename Avatar `offline` class

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/upgrade/+page.md

The `offline` class for avatars has been renamed to `avatar-offline`. Update your HTML to reflect this change.

```diff
- <div class="avatar offline">
+ <div class="avatar avatar-offline">
  <div class="w-24 rounded-full">
    <img src="https://img.daisyui.com/images/stock/photo-1534528741775-53994a69daeb.webp" />
  </div>
</div>
```

--------------------------------

### Configure Context7 MCP Server in Cursor

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/editor/cursor/+page.md

Adds Context7 as a custom MCP server in Cursor's global configuration. This allows Cursor to communicate with the Context7 AI model for potentially more accurate results when generating daisyUI code.

```json
{
  "mcpServers": {
    "Context7": {
      "type": "stdio",
      "command": "npx",
      "args": ["-y", "@upstash/context7-mcp@latest"]
    }
  }
}
```

--------------------------------

### Basic daisyUI Button HTML Structure

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/customize/+page.md

This snippet shows the fundamental HTML structure for a daisyUI button component, serving as a starting point before any specific customizations are applied.

```HTML
<button class="btn">Button</button>
```

--------------------------------

### Add Context7 MCP Server Configuration for Claude

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/editor/claude/+page.md

This snippet shows how to add the Context7 MCP server configuration to Claude desktop's developer settings. It enables Claude to use Context7 for more accurate AI model communication, specifically for daisyUI code generation. The configuration involves adding a new server entry to the `mcpServers` object in the `claude_desktop_config.json` file.

```json
{
  "mcpServers": {
    "Context7": {
      "type": "stdio",
      "command": "npx",
      "args": ["-y", "@upstash/context7-mcp@latest"]
    }
  }
}
```

--------------------------------

### Add Vite preprocessor to SvelteKit configuration

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/how-to-install-sveltekit-and-daisyui/+page.md

Updates `svelte.config.js` to include `vitePreprocess` from `@sveltejs/vite-plugin-svelte`. This enables SvelteKit to process various file types, including PostCSS for Tailwind CSS, during the build process.

```javascript
import adapter from '@sveltejs/adapter-auto';
import { vitePreprocess } from '@sveltejs/vite-plugin-svelte';
/** @type {import('@sveltejs/kit').Config} */
const config = {
  preprocess: vitePreprocess(),
  kit: {
    // adapter-auto only supports some environments, see https://kit.svelte.dev/docs/adapter-auto for a list.
    // If your environment is not supported or you settled on a specific environment, switch out the adapter.
    // See https://kit.svelte.dev/docs/adapters for more information about adapters.
    adapter: adapter()
  }
};

export default config;
```

--------------------------------

### Integrate React Day Picker

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/calendar/+page.md

Shows how to install and use React Day Picker in a React application, demonstrating single date selection and popover integration for displaying the calendar.

```bash
npm i react-day-picker
```

```jsx
import { useState } from "react";
import { DayPicker } from "react-day-picker";

export default function App() {
  const [date, setDate] = useState<Date | undefined>();
  return (
    <>
      <button popoverTarget="rdp-popover" className="$$input $$input-border" style={{ anchorName: "--rdp" } as React.CSSProperties}>
        {date ? date.toLocaleDateString() : "Pick a date"}
      </button>
      <div popover="auto" id="rdp-popover" className="$$dropdown" style={{ positionAnchor: "--rdp" } as React.CSSProperties}>
        <DayPicker className="$$react-day-picker" mode="single" selected={date} onSelect={setDate} />
      </div>
    </>
  );
}
```

--------------------------------

### Import global CSS file in SvelteKit page

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/sveltekit/+page.md

This Svelte component snippet demonstrates how to import the global `app.css` file into a Svelte page or layout. By importing it within a `<script>` block, the styles defined in `app.css` (including Tailwind CSS and daisyUI) become available throughout the component and its children. This ensures your UI components are styled correctly.

```html
<script>
  import "../app.css";
</script>
```

--------------------------------

### Create DaisyUI Window Mockup with Border

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/mockup-window/+page.md

This HTML snippet demonstrates how to render a window mockup using DaisyUI. It applies `mockup-window` and `border` classes to simulate an operating system window with a distinct border, suitable for UI demonstrations.

```html
<div class="mockup-window border border-base-300 w-full">
  <div class="grid place-content-center border-t border-base-300 h-80">Hello!</div>
</div>
```

--------------------------------

### daisyUI 5 CSS Structure (Node Dependency)

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/static/llms.txt

This CSS code demonstrates how to integrate daisyUI 5 into a project when installed as a Node dependency. It requires importing Tailwind CSS first, followed by the daisyUI plugin.

```css
@import "tailwindcss";
@plugin "daisyui";
```

--------------------------------

### Generate Tailwind CSS Output

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/django/+page.md

Executes the Tailwind CSS CLI to process `input.css` and generate the final `output.css` file. The `--watch` flag enables continuous compilation during development, while omitting it is suitable for CI/CD environments.

```sh
myapp/static/css/tailwindcss -i myapp/static/css/input.css -o myapp/static/css/output.css --watch
# For Windows
myapp\static\css\tailwindcss.exe -i myapp/static/css/input.css -o myapp/static/css/output.css --watch
```

--------------------------------

### Position a Tooltip to the Right in HTML

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/tooltip/+page.md

Demonstrates how to position the tooltip to the right of the target element using the `tooltip-right` class. This example also forces the tooltip open for visibility.

```HTML
<div class="$$tooltip $$tooltip-open $$tooltip-right" data-tip="hello">
  <button class="$$btn">Right</button>
</div>
```

--------------------------------

### Position a Tooltip to the Left in HTML

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/tooltip/+page.md

Demonstrates how to position the tooltip to the left of the target element using the `tooltip-left` class. This example also forces the tooltip open for visibility.

```HTML
<div class="$$tooltip $$tooltip-open $$tooltip-left" data-tip="hello">
  <button class="$$btn">Left</button>
</div>
```

--------------------------------

### Importing Svelte Component

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/pages/best-component-library-for-beginners/+page.md

This snippet demonstrates how to import a Svelte component, typically used within a SvelteKit application. It allows for the use of modular UI elements across different pages or components, enhancing code reusability and organization.

```Svelte
import Translate from "$components/Translate.svelte"
```

--------------------------------

### Configure daisyUI in project CSS

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/waku/+page.md

This code snippet shows how to integrate daisyUI into your project's CSS file, typically `src/styles.css`. By adding `@plugin "daisyui";`, you import daisyUI's styles and components, allowing you to use its utility classes and themes within your Waku application.

```css
@import "tailwindcss";
@plugin "daisyui";
```

--------------------------------

### Configure GitMCP Server for daisyUI Docs

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/editor/cline/+page.md

This JSON snippet shows how to update Cline's MCP server settings to include the daisyUI GitMCP server. By adding this configuration, Cline can directly access daisyUI documentation for AI model interactions, enabling more context-aware responses.

```json
{
  "mcpServers": {
    "daisyui Docs": {
      "url": "https://gitmcp.io/saadeghi/daisyui",
      "disabled": false,
      "autoApprove": []
    }
  }
}
```

--------------------------------

### Use daisyUI llms.txt in VSCode Chat (Markdown Prompt)

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/editor/vscode/+page.md

This snippet shows how to instruct VSCode's AI assistant to use the daisyUI llms.txt file for generating code. It's a quick method for immediate use within the chat window.

```md:prompt
#fetch https://daisyui.com/llms.txt
```

--------------------------------

### Example: Customizing daisyUI Root Selector

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/config/+page.md

Shows how to change the CSS selector where daisyUI applies its global CSS variables, useful for scoping styles to a specific element like a web component or shadow DOM.

```postcss
@plugin "daisyui" {
  root: "#my-app";
}
```

--------------------------------

### Configure PostCSS for Tailwind CSS in Rsbuild

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/rsbuild/+page.md

Create a `postcss.config.mjs` file in your project root and configure it to use the Tailwind CSS PostCSS plugin. This allows Rsbuild to process Tailwind directives.

```js
const config = {
  plugins: {
    '@tailwindcss/postcss': {},
  },
};
export default config;
```

--------------------------------

### Import Tailwind CSS and daisyUI in PostCSS

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/vite/+page.md

Adds `@import` rules for Tailwind CSS and `@plugin` for daisyUI into your main CSS file (e.g., `src/style.css`). This integrates both frameworks into your project's stylesheet, making their utility classes and components available.

```postcss
@import "tailwindcss";
@plugin "daisyui";
```

--------------------------------

### Configure PostCSS for Tailwind CSS

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/nextjs/+page.md

Configures the `postcss.config.mjs` file to include Tailwind CSS as a PostCSS plugin. This step ensures that Tailwind's utility classes are processed and generated correctly during the build process.

```js
/** @type {import('postcss-load-config').Config} */
const config = {
  plugins: {
    '@tailwindcss/postcss': {},
  },
};
export default config;
```

--------------------------------

### Homepage Structure in Next.js (page.tsx)

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/daisyui-nextjs-online-store-template/+page.md

Illustrates the basic structure of the `app/page.tsx` file, showing how different components like Hero, Features, and Product sections are rendered on the homepage of the Next.js store. This file serves as the main entry point for the site's landing page.

```tsx
export default async function Home() {
  return (
    <div>
      <Hero />
      <Features />
      <TrendingProducts />
      <Categories />
      <OfferCard />
      <NewArrivals />
      <NewsLetter />
    </div>
  );
}
```

--------------------------------

### Configure Vite to use Tailwind CSS plugin

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/lit/+page.md

Modifies the Vite configuration file (`vite.config.js`) to import and include the Tailwind CSS plugin, enabling Tailwind processing during development and build.

```js
import { defineConfig } from 'vite';
import tailwindcss from '@tailwindcss/vite';

export default defineConfig({
  plugins: [
    tailwindcss()
  ]
});
```

--------------------------------

### Basic DaisyUI Card Component Example

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/card/+page.md

This HTML snippet demonstrates a basic DaisyUI card component with an image, title, paragraph content, and an action button. It showcases the structure using `card`, `card-body`, `card-title`, and `card-actions` classes, along with utility classes for styling.

```html
<div class="$$card bg-base-100 w-96 shadow-sm">
  <figure>
    <img
      src="https://img.daisyui.com/images/stock/photo-1606107557195-0e29a4b5b4aa.webp"
      alt="Shoes" />
  </figure>
  <div class="$$card-body">
    <h2 class="$$card-title">Card Title</h2>
    <p>A card component has a figure, a body part, and inside body there are title and actions parts</p>
    <div class="$$card-actions justify-end">
      <button class="$$btn $$btn-primary">Buy Now</button>
    </div>
  </div>
</div>
```

--------------------------------

### Embed DaisyUI Kbd within a text block

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/kbd/+page.md

Illustrates how to integrate a `kbd` component seamlessly within a sentence to highlight a keyboard shortcut in context. This example uses the small size modifier for better text flow.

```html
Press
<kbd class="$$kbd $$kbd-sm">F</kbd>
to pay respects.
```

--------------------------------

### Create SvelteKit layout to import Tailwind CSS

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/how-to-install-sveltekit-and-daisyui/+page.md

Generates a new `src/routes/+layout.svelte` file. This layout component imports the main Tailwind CSS stylesheet, ensuring that Tailwind's utility classes are available globally across all routes in the SvelteKit application.

```shell
echo '\n<script>\n  import "tailwindcss/tailwind.css";\n</script>\n\n<slot />\n' > src/routes/+layout.svelte
```

--------------------------------

### Create a disabled Textarea

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/textarea/+page.md

This example demonstrates how to render a textarea in a disabled state, preventing user interaction. This is useful for displaying non-editable content or indicating that input is not currently allowed.

```html
<textarea class="$$textarea" placeholder="Bio" disabled></textarea>
```

--------------------------------

### Login Form using Fieldset

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/fieldset/+page.md

Provides a complete example of structuring a login form within a Fieldset, including input fields for email and password, associated labels, and a submit button, all logically grouped.

```html
<fieldset class="fieldset bg-base-200 border-base-300 rounded-box w-xs border p-4">
  <legend class="fieldset-legend">Login</legend>

  <label class="label">Email</label>
  <input type="email" class="input" placeholder="Email" />

  <label class="label">Password</label>
  <input type="password" class="input" placeholder="Password" />

  <button class="btn btn-neutral mt-4">Login</button>
</fieldset>
```

--------------------------------

### DaisyUI Footer with Templated Classes

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/footer/+page.md

This DaisyUI footer example demonstrates the use of `$$` placeholders for class names, suggesting a templating or dynamic class injection mechanism. It maintains the copyright display with a dynamic year.

```html
<footer class="$$footer $$sm:footer-horizontal $$footer-center bg-base-300 text-base-content p-4">
  <aside>
    <p>Copyright © {new Date().getFullYear()} - All right reserved by ACME Industries Ltd</p>
  </aside>
</footer>
```

--------------------------------

### Migrate DaisyUI Form Control with Alt Labels

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/upgrade/+page.md

This snippet demonstrates migrating `form-control` and `label-text-alt` classes to a `fieldset` and `label` structure with flex utilities. It shows how to achieve similar multi-label layouts using the new recommended DaisyUI classes, enhancing flexibility and maintainability.

```html
<label class="form-control w-full max-w-xs">
  <div class="label">
    <span class="label-text">What is your name?</span>
    <span class="label-text-alt">Top Right label</span>
  </div>
  <input type="text" placeholder="Type here" class="input input-bordered w-full max-w-xs" />
  <div class="label">
    <span class="label-text-alt">Bottom Left label</span>
    <span class="label-text-alt">Bottom Right label</span>
  </div>
</label>
```

```html
<fieldset class="fieldset max-w-xs">
  <label class="label flex justify-between" for="name">
    <span>What is your name?</span>
    <span>Top Right label</span>
  </label>
  <input id="name" class="input" placeholder="Name" />
  <label class="label flex justify-between" for="name">
    <span>Bottom Left label</span>
    <span>Bottom Right label</span>
  </label>
</fieldset>
```

--------------------------------

### HTML Indicator: Bottom-Center Position

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/indicator/+page.md

Shows the DaisyUI indicator component positioned at the bottom-center of its parent. This setup utilizes the `indicator-bottom` and `indicator-center` utility classes for a secondary badge.

```html
<div class="$$indicator">
  <span
    class="$$indicator-item $$indicator-bottom $$indicator-center $$badge $$badge-secondary"
  ></span>
  <div class="bg-base-300 grid h-32 w-32 place-items-center">content</div>
</div>
```

--------------------------------

### Product Details Page Structure in Next.js (products/[slug].tsx)

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/daisyui-nextjs-online-store-template/+page.md

Demonstrates the layout for the `app/products/[slug].tsx` file, which handles individual product details. This page dynamically displays product images, information, and variants based on the product's slug.

```tsx
const ProductDetails = () => {
  return (
    <div className="pb-20">
      <div className="mt-10 flex flex-col">
        <div className="flex flex-col lg:grid gap-6 lg:gap-12 lg:grid-cols-2">
          <ProductImage params={{ slug: slug as string }} />
        </div>
      </div>
    </div>
  );
}
```

--------------------------------

### HTML Indicator: Top-Center Position

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/indicator/+page.md

Shows the DaisyUI indicator component positioned at the top-center of its parent. This setup utilizes the `indicator-top` and `indicator-center` utility classes for a secondary badge.

```html
<div class="$$indicator">
  <span class="$$indicator-item $$indicator-center $$badge $$badge-secondary"></span>
  <div class="bg-base-300 grid h-32 w-32 place-items-center">content</div>
</div>
```

--------------------------------

### Customizing daisyUI Buttons with Built-in Utility Classes

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/customize/+page.md

This example demonstrates how to apply daisyUI's predefined utility classes, such as `btn-primary`, `btn-secondary`, `btn-accent`, and `btn-outline`, to modify the appearance and style of button components.

```HTML
<button class="btn btn-primary">One</button>
<button class="btn btn-secondary">Two</button>
<button class="btn btn-accent btn-outline">Three</button>
```

--------------------------------

### Configure Vite for UnoCSS

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/unocss/+page.md

This JavaScript configuration file for Vite integrates UnoCSS as a plugin. It ensures that UnoCSS processes your project's files during the build process, enabling utility-first CSS generation.

```vite.config.js
import { defineConfig } from 'vite';
import unocss from "unocss/vite";

export default defineConfig({
  plugins: [
    unocss()
  ]
});
```

--------------------------------

### HTML Indicator: Middle-Center Position

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/indicator/+page.md

Shows the DaisyUI indicator component positioned at the middle-center of its parent. This setup utilizes the `indicator-middle` and `indicator-center` utility classes for a secondary badge.

```html
<div class="$$indicator">
  <span
    class="$$indicator-item $$indicator-middle $$indicator-center $$badge $$badge-secondary"
  ></span>
  <div class="bg-base-300 grid h-32 w-32 place-items-center">content</div>
</div>
```

--------------------------------

### Import UnoCSS into main JavaScript file

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/unocss/+page.md

These import statements in the main JavaScript entry point (`src/main.js`) bring in the UnoCSS reset styles and the generated UnoCSS utilities. This ensures that the compiled CSS is applied to your application.

```src/main.js
import "@unocss/reset/tailwind.css";
import "uno.css";
```

--------------------------------

### Import application CSS into Astro Layout

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/astro/+page.md

This Astro layout file (`src/layouts/Layout.astro`) imports the main application CSS file (`../assets/app.css`). This ensures that the Tailwind CSS and daisyUI styles are applied globally across your Astro pages.

```js
---
import "../assets/app.css";
---
```

--------------------------------

### Apply an Indicator to a Tab with DaisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/indicator/+page.md

This example demonstrates how to use an indicator with a tab component. A badge showing '8' is placed on the 'Notifications' tab, indicating new messages or items within that tab.

```html
<div class="$$tabs $$tabs-lift">
  <a class="$$tab">Messages</a>
  <a class="$$indicator $$tab $$tab-active">
    Notifications
    <span class="$$indicator-item $$badge">8</span>
  </a>
  <a class="$$tab">Requests</a>
</div>
```

--------------------------------

### Configure Django URL Routing

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/django/+page.md

Modifies `myapp/urls.py` to include the new home view. It maps the root URL path ('') to the `home` function defined in `views.py`, making the homepage accessible.

```python
from django.contrib import admin
from django.urls import path
from . import views

urlpatterns = [
    path("admin/", admin.site.urls),
    path("", views.home, name="home"),
]
```

--------------------------------

### Basic daisyUI Component Usage

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/pages/best-component-library-for-beginners/+page.md

This HTML snippet shows the most basic way to use a daisyUI component, applying only the component's primary class. It's ideal for beginners who want to quickly integrate pre-styled elements without further customization.

```html
<!-- Beginner: using components as they come -->
<button class="btn">Button</button>
```

--------------------------------

### Configure Tailwind CSS and daisyUI in PostCSS

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/elysia/+page.md

Configures the main CSS file to import Tailwind CSS and daisyUI. It specifies the source for Tailwind and enables the daisyUI plugin, allowing their utility classes and components to be used.

```postcss
@import "tailwindcss" source(none);
@source "../public";
@plugin "daisyui";
```

--------------------------------

### Import Tailwind CSS and daisyUI into application CSS

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/nuxt/+page.md

Imports Tailwind CSS and daisyUI directives into the main application CSS file (`app.css`) using PostCSS `@import` and `@plugin` rules, making their styles available.

```postcss
@import "tailwindcss";
@plugin "daisyui";
```

--------------------------------

### Basic Avatar Component

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/avatar/+page.md

Demonstrates the basic structure of an avatar component using a `div` with `avatar` class and an `img` tag inside a sized and rounded container. This is the fundamental setup for displaying a user or entity thumbnail.

```html
<div class="$$avatar">
  <div class="w-24 rounded">
    <img src="https://img.daisyui.com/images/profile/demo/batperson@192.webp" />
  </div>
</div>
```

--------------------------------

### Customizing daisyUI Components with Tailwind CSS

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/pages/best-component-library-for-beginners/+page.md

This HTML snippet demonstrates how to customize a daisyUI component by adding extra Tailwind CSS utility classes. This approach allows for more granular control over styling while still leveraging daisyUI's base components, suitable for intermediate users.

```html
<!-- Intermediate: customizing with additional Tailwind classes -->
<button class="btn rounded-full px-6">Custom Button</button>
```

--------------------------------

### Import Tailwind CSS and daisyUI in PostCSS

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/astro/+page.md

This PostCSS snippet (`src/assets/app.css`) imports the core Tailwind CSS utilities and the daisyUI plugin. It's crucial for making Tailwind's utility classes and daisyUI components available in your project's stylesheets.

```postcss
@import "tailwindcss";
@plugin "daisyui";
```

--------------------------------

### Create Simple Navigation Buttons for Pagination in DaisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/pagination/+page.md

This snippet provides a basic example of navigation buttons (e.g., 'previous' and 'next') within a pagination context. It showcases the use of the `join` container to group these buttons and the `btn` class for styling, suitable for simple page navigation interfaces.

```HTML
<div class="join">
  <button class="join-item btn">«</button>
  <button class="join-item btn">Page 22</button>
  <button class="join-item btn">»</button>
</div>
```

--------------------------------

### Basic Astro Blog Post Markdown Structure

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/how-to-make-a-blog-quickly-using-astro-and-daisyUI/+page.md

This Markdown snippet shows the basic frontmatter and content structure for a new blog post in the Astro template. It includes metadata fields like title, description, date, image, author, and category, followed by the main content area.

```markdown
---
title: Boosting Sales with Effective Search Engine Optimization (SEO)
description: Lorem ipsum dolor sit, amet consectetur adipisicing elit. Hic eos odit sequi minima iure natus, odio tempora sit Lorem ipsum dolor sit.
date: 2024/01/12
image: ./images/post-1.jpg
author: antonio
authorImage: /images/about.jpeg
category: seo
---

<script>
  import Translate from "$components/Translate.svelte"
</script>
```

--------------------------------

### HTML Indicator: Bottom-End Position

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/indicator/+page.md

Demonstrates the DaisyUI indicator component positioned at the bottom-end of its parent. This example uses the `indicator-bottom` class, with `indicator-end` being the default horizontal position for the badge.

```html
<div class="$$indicator">
  <span class="$$indicator-item $$indicator-bottom $$badge $$badge-secondary"></span>
  <div class="bg-base-300 grid h-32 w-32 place-items-center">content</div>
</div>
```

--------------------------------

### HTML Indicator: Top-End Position

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/indicator/+page.md

Demonstrates the DaisyUI indicator component positioned at the top-end of its parent. This example uses the `indicator-top` class, with `indicator-end` being the default horizontal position for the badge.

```html
<div class="$$indicator">
  <span class="$$indicator-item $$badge $$badge-secondary"></span>
  <div class="bg-base-300 grid h-32 w-32 place-items-center">content</div>
</div>
```

--------------------------------

### Create Date Input Label (DaisyUI)

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/label/+page.md

Provides an example of labeling a date input field. The 'span' with class 'label' is used to display the 'Publish date' text, ensuring the purpose of the input is clear.

```html
<label class="input">
  <span class="label">Publish date</span>
  <input type="date" />
</label>
```

```html
<label class="$$input">
  <span class="$$label">Publish date</span>
  <input type="date" />
</label>
```

--------------------------------

### Create UnoCSS configuration file

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/unocss/+page.md

This JavaScript file defines the UnoCSS configuration, including content scanning paths and presets. It uses `presetDaisy` for daisyUI components and `presetWind4` for Tailwind CSS-like utilities, allowing UnoCSS to generate the necessary styles.

```unocss.config.js
import { defineConfig } from "unocss";
import presetWind4 from "@unocss/preset-wind4";
import { presetDaisy } from "@ameinhardt/unocss-preset-daisy";

export default defineConfig({
  content: {
    pipeline: {
      include: ["src/**/*.{js,ts}"]
    }
  },
  presets: [presetDaisy(), presetWind4()]
});
```

--------------------------------

### HTML Indicator: Middle-End Position

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/indicator/+page.md

Demonstrates the DaisyUI indicator component positioned at the middle-end of its parent. This example uses the `indicator-middle` class, with `indicator-end` being the default horizontal position for the badge.

```html
<div class="$$indicator">
  <span class="$$indicator-item $$indicator-middle $$badge $$badge-secondary"></span>
  <div class="bg-base-300 grid h-32 w-32 place-items-center">content</div>
</div>
```

--------------------------------

### Add an Indicator to an Input Field with DaisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/indicator/+page.md

This example demonstrates how to use an indicator with an input field. A 'Required' badge is placed next to the input, providing a visual cue for mandatory fields.

```html
<div class="$$indicator">
  <span class="$$indicator-item $$badge">Required</span>
  <input type="text" placeholder="Your email address" class="$$input $$input-bordered" />
</div>
```

--------------------------------

### Navigate to Next.js project directory

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/install-daisyui-and-tailwindcss-in-nextjs/+page.md

After creating the Next.js project, use this command to change the current directory to the newly created project folder. Replace `my-app` with the actual name you provided for your project.

```bash
cd my-app
```

--------------------------------

### Long Line Code Mockup with Scrolling

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/mockup-code/+page.md

Demonstrates how a long line of code is displayed within the mockup, indicating that it will scroll horizontally if it exceeds the container width. The example provides both the long text and its HTML structure.

```Text
Magnam dolore beatae necessitatibus nemopsum itaque sit. Et porro quae qui et et dolore ratione.
```

```HTML
<div class="$$mockup-code w-full">
  <pre
    data-prefix="~"><code>Magnam dolore beatae necessitatibus nemopsum itaque sit. Et porro quae qui et et dolore ratione.</code></pre>
</div>
```

--------------------------------

### Horizontal Divider with Text

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/divider/+page.md

This example shows how to create a horizontal divider with text 'OR' to separate content placed side-by-side. The `divider-horizontal` class explicitly sets the orientation.

```HTML
<div class="flex w-full">
  <div class="$$card bg-base-300 rounded-box grid h-20 grow place-items-center">content</div>
  <div class="$$divider $$divider-horizontal">OR</div>
  <div class="$$card bg-base-300 rounded-box grid h-20 grow place-items-center">content</div>
</div>
```

--------------------------------

### Import Tailwind CSS and daisyUI into main stylesheet

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/vue/+page.md

Adds `@import` and `@plugin` directives to the main CSS file (e.g., `src/style.css`) to integrate Tailwind CSS and daisyUI into the project's styling. This makes their utility classes and components available for use.

```postcss
@import "tailwindcss";
@plugin "daisyui";
```

--------------------------------

### Success Color Alert Component Example

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/alert/+page.md

Illustrates an alert component styled with the 'success' color, indicating a successful operation. It features an SVG icon and a confirmation message, providing positive feedback to the user.

```HTML
<div role="alert" class="$$alert $$alert-success">
  <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6 shrink-0 stroke-current" fill="none" viewBox="0 0 24 24">
    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 12l2 2 4-4m6 2a9 9 0 11-18 0 9 9 0 0118 0z" />
  </svg>
  <span>Your purchase has been confirmed!</span>
</div>
```

--------------------------------

### DaisyUI HTML Footer Component with Navigation Links

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/footer/+page.md

This code snippet provides two variations of a responsive HTML footer component, designed with DaisyUI. It includes a logo, company information, and structured navigation links for services, company details, and legal policies. The first version uses `<button>` elements for navigation, while the second uses `<a>` tags and includes placeholder prefixes (`$$`) for DaisyUI classes, indicating a templated or example usage.

```html
<footer class="p-10 footer sm:footer-horizontal bg-base-200 text-base-content rounded">
  <aside>
    <svg width="50" height="50" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg" fill-rule="evenodd" clip-rule="evenodd" class="fill-current"><path d="M22.672 15.226l-2.432.811.841 2.515c.33 1.019-.209 2.127-1.23 2.456-1.15.325-2.148-.321-2.463-1.226l-.84-2.518-5.013 1.677.84 2.517c.391 1.203-.434 2.542-1.831 2.542-.88 0-1.601-.564-1.86-1.314l-.842-2.516-2.431.809c-1.135.328-2.145-.317-2.463-1.229-.329-1.018.211-2.127 1.231-2.456l2.432-.809-1.621-4.823-2.432.808c-1.355.384-2.558-.59-2.558-1.839 0-.817.509-1.582 1.327-1.846l2.433-.809-.842-2.515c-.33-1.02.211-2.129 1.232-2.458 1.02-.329 2.13.209 2.461 1.229l.842 2.515 5.011-1.677-.839-2.517c-.403-1.238.484-2.553 1.843-2.553.819 0 1.585.509 1.85 1.326l.841 2.517 2.431-.81c1.02-.33 2.131.211 2.461 1.229.332 1.018-.21 2.126-1.23 2.456l-2.433.809 1.622 4.823 2.433-.809c1.242-.401 2.557.484 2.557 1.838 0 .819-.51 1.583-1.328 1.847m-8.992-6.428l-5.01 1.675 1.619 4.828 5.011-1.674-1.62-4.829z"></path></svg>
    <p>ACME Industries Ltd.<br>Providing reliable tech since 1992</p>
  </aside>
  <nav>
    <h6 class="footer-title">Services</h6>
    <button class="link link-hover">Branding</button>
    <button class="link link-hover">Design</button>
    <button class="link link-hover">Marketing</button>
    <button class="link link-hover">Advertisement</button>
  </nav>
  <nav>
    <h6 class="footer-title">Company</h6>
    <button class="link link-hover">About us</button>
    <button class="link link-hover">Contact</button>
    <button class="link link-hover">Jobs</button>
    <button class="link link-hover">Press kit</button>
  </nav>
  <nav>
    <h6 class="footer-title">Legal</h6>
    <button class="link link-hover">Terms of use</button>
    <button class="link link-hover">Privacy policy</button>
    <button class="link link-hover">Cookie policy</button>
  </nav>
</footer>
```

```html
<footer class="$$footer sm:$$footer-horizontal bg-base-200 text-base-content p-10">
  <aside>
    <svg
      width="50"
      height="50"
      viewBox="0 0 24 24"
      xmlns="http://www.w3.org/2000/svg"
      fill-rule="evenodd"
      clip-rule="evenodd"
      class="fill-current">
      <path
        d="M22.672 15.226l-2.432.811.841 2.515c.33 1.019-.209 2.127-1.23 2.456-1.15.325-2.148-.321-2.463-1.226l-.84-2.518-5.013 1.677.84 2.517c.391 1.203-.434 2.542-1.831 2.542-.88 0-1.601-.564-1.86-1.314l-.842-2.516-2.431.809c-1.135.328-2.145-.317-2.463-1.229-.329-1.018.211-2.127 1.231-2.456l2.432-.809-1.621-4.823-2.432.808c-1.355.384-2.558-.59-2.558-1.839 0-.817.509-1.582 1.327-1.846l2.433-.809-.842-2.515c-.33-1.02.211-2.129 1.232-2.458 1.02-.329 2.13.209 2.461 1.229l.842 2.515 5.011-1.677-.839-2.517c-.403-1.238.484-2.553 1.843-2.553.819 0 1.585.509 1.85 1.326l.841 2.517 2.431-.81c1.02-.33 2.131.211 2.461 1.229.332 1.018-.21 2.126-1.23 2.456l-2.433.809 1.622 4.823 2.433-.809c1.242-.401 2.557.484 2.557 1.838 0 .819-.51 1.583-1.328 1.847m-8.992-6.428l-5.01 1.675 1.619 4.828 5.011-1.674-1.62-4.829z"></path>
    </svg>
    <p>
      ACME Industries Ltd.
      <br />
      Providing reliable tech since 1992
    </p>
  </aside>
  <nav>
    <h6 class="$$footer-title">Services</h6>
    <a class="$$link $$link-hover">Branding</a>
    <a class="$$link $$link-hover">Design</a>
    <a class="$$link $$link-hover">Marketing</a>
    <a class="$$link $$link-hover">Advertisement</a>
  </nav>
  <nav>
    <h6 class="$$footer-title">Company</h6>
    <a class="$$link $$link-hover">About us</a>
    <a class="$$link $$link-hover">Contact</a>
    <a class="$$link $$link-hover">Jobs</a>
    <a class="$$link $$link-hover">Press kit</a>
  </nav>
  <nav>
    <h6 class="$$footer-title">Legal</h6>
    <a class="$$link $$link-hover">Terms of use</a>
    <a class="$$link $$link-hover">Privacy policy</a>
    <a class="$$link $$link-hover">Cookie policy</a>
  </nav>
</footer>
```

--------------------------------

### DaisyUI Disabled Radio Button Example

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/radio/+page.md

Demonstrates how to render disabled radio buttons using DaisyUI classes. This snippet shows both checked and unchecked disabled states for a radio input.

```html
<input type="radio" name="radio-11" class="$$radio" disabled checked="checked" />
<input type="radio" name="radio-11" class="$$radio" disabled />
```

--------------------------------

### HTML for DaisyUI Badges with Soft Style

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/badge/+page.md

Provides examples of badges styled with a 'soft' appearance, achieved by combining the `badge-soft` class with various color themes. This style offers a subtle background fill.

```HTML
<div class="$$badge $$badge-soft $$badge-primary">Primary</div>
<div class="$$badge $$badge-soft $$badge-secondary">Secondary</div>
<div class="$$badge $$badge-soft $$badge-accent">Accent</div>
<div class="$$badge $$badge-soft $$badge-info">Info</div>
<div class="$$badge $$badge-soft $$badge-success">Success</div>
<div class="$$badge $$badge-soft $$badge-warning">Warning</div>
<div class="$$badge $$badge-soft $$badge-error">Error</div>
```

--------------------------------

### Integrate Tailwind CSS plugin into Fresh configuration

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/fresh/+page.md

Modifies the `fresh.config.ts` file to import and register the `fresh-plugin-tailwindcss` plugin. This configuration ensures that Tailwind CSS is processed and applied correctly within the Deno Fresh application's build pipeline.

```typescript
import { defineConfig } from "$fresh/server.ts";
import tailwind from "@pakornv/fresh-plugin-tailwindcss";

export default defineConfig({
  plugins: [tailwind()],
});
```

--------------------------------

### Implement DaisyUI Alert with Soft Style

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/alert/+page.md

This snippet demonstrates how to create alert components using DaisyUI's 'soft' style. It includes examples for info, success, warning, and error states, showcasing different background and text color combinations for a subtle appearance.

```html
<div role="alert" class="$$alert $$alert-info $$alert-soft">
  <span>12 unread messages. Tap to see.</span>
</div>
<div role="alert" class="$$alert $$alert-success $$alert-soft">
  <span>Your purchase has been confirmed!</span>
</div>
<div role="alert" class="$$alert $$alert-warning $$alert-soft">
  <span>Warning: Invalid email address!</span>
</div>
<div role="alert" class="$$alert $$alert-error $$alert-soft">
  <span>Error! Task failed successfully.</span>
</div>
```

--------------------------------

### Basic DaisyUI Menu Example

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/menu/+page.md

This snippet demonstrates a fundamental vertical menu structure using DaisyUI. It applies the `menu` class to the `<ul>` element, along with `bg-base-200` for background color and `rounded-box` for rounded corners, creating a simple and styled navigation list.

```html
<ul class="$$menu bg-base-200 $$rounded-box w-56">
  <li><a>Item 1</a></li>
  <li><a>Item 2</a></li>
  <li><a>Item 3</a></li>
</ul>
```

--------------------------------

### Create a Helper Dropdown with DaisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/dropdown/+page.md

This example illustrates the creation of a compact, contextual helper dropdown using DaisyUI. It features a small, circular button with an SVG icon that, when clicked, reveals a card-style content area, ideal for displaying supplementary information or tooltips.

```html
A normal text and a helper dropdown
<div class="$$dropdown $$dropdown-end">
  <div tabindex="0" role="button" class="$$btn $$btn-circle $$btn-ghost $$btn-xs text-info">
    <svg
      tabindex="0"
      xmlns="http://www.w3.org/2000/svg"
      fill="none"
      viewBox="0 0 24 24"
      class="h-4 w-4 stroke-current">
      <path
        stroke-linecap="round"
        stroke-linejoin="round"
        stroke-width="2"
        d="M13 16h-1v-4h-1m1-4h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z"></path>
    </svg>
  </div>
  <div
    tabindex="0"
    class="$$card $$card-sm $$dropdown-content bg-base-100 rounded-box z-1 w-64 shadow-sm">
    <div tabindex="0" class="$$card-body">
      <h2 class="$$card-title">You needed more info?</h2>
      <p>Here is a description!</p>
    </div>
  </div>
</div>
```

--------------------------------

### Configure Lemon Squeezy API Key

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/daisyui-nextjs-online-store-template/+page.md

Add your Lemon Squeezy API key to the project's `.env` file. This environment variable is crucial for the application to authenticate and fetch product data directly from the Lemon Squeezy API.

```bash
LEMON_SQUEEZY_API_KEY=your_api_key_here
```

--------------------------------

### Basic DaisyUI Stat Component with Icons

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/stat/+page.md

This HTML snippet demonstrates a standard 'Stat' component from DaisyUI, typically used to display various metrics with an associated SVG icon, title, value, and a descriptive text. It includes examples for downloads, new users, and new registrations, showcasing a common layout for data presentation.

```html
<div class="$$stats shadow">
  <div class="$$stat">
    <div class="$$stat-figure text-secondary">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        fill="none"
        viewBox="0 0 24 24"
        class="inline-block h-8 w-8 stroke-current"
      >
        <path
          stroke-linecap="round"
          stroke-linejoin="round"
          stroke-width="2"
          d="M13 16h-1v-4h-1m1-4h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z"
        ></path>
      </svg>
    </div>
    <div class="$$stat-title">Downloads</div>
    <div class="$$stat-value">31K</div>
    <div class="$$stat-desc">Jan 1st - Feb 1st</div>
  </div>

  <div class="$$stat">
    <div class="$$stat-figure text-secondary">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        fill="none"
        viewBox="0 0 24 24"
        class="inline-block h-8 w-8 stroke-current"
      >
        <path
          stroke-linecap="round"
          stroke-linejoin="round"
          stroke-width="2"
          d="M12 6V4m0 2a2 2 0 100 4m0-4a2 2 0 110 4m-6 8a2 2 0 100-4m0 4a2 2 0 110-4m0 4v2m0-6V4m6 6v10m6-2a2 2 0 100-4m0 4a2 2 0 110-4m0 4v2m0-6V4"
        ></path>
      </svg>
    </div>
    <div class="$$stat-title">New Users</div>
    <div class="$$stat-value">4,200</div>
    <div class="$$stat-desc">↗︎ 400 (22%)</div>
  </div>

  <div class="$$stat">
    <div class="$$stat-figure text-secondary">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        fill="none"
        viewBox="0 0 24 24"
        class="inline-block h-8 w-8 stroke-current"
      >
        <path
          stroke-linecap="round"
          stroke-linejoin="round"
          stroke-width="2"
          d="M5 8h14M5 8a2 2 0 110-4h14a2 2 0 110 4M5 8v10a2 2 0 002 2h10a2 2 0 002-2V8m-9 4h4"
        ></path>
      </svg>
    </div>
    <div class="$$stat-title">New Registers</div>
    <div class="$$stat-value">1,200</div>
    <div class="$$stat-desc">↘︎ 90 (14%)</div>
  </div>
</div>
```

--------------------------------

### Display common function and modifier keys with DaisyUI Kbd

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/kbd/+page.md

Provides examples of using the `kbd` component to display special function keys and common modifier symbols like Command (⌘), Option (⌥), Shift (⇧), and Control (⌃).

```html
<kbd class="$$kbd">⌘</kbd>
<kbd class="$$kbd">⌥</kbd>
<kbd class="$$kbd">⇧</kbd>
<kbd class="$$kbd">⌃</kbd>
```

--------------------------------

### Apply Shadows to Stacked Cards in DaisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/stack/+page.md

This example illustrates how to add different shadow effects to individual cards within a stacked layout. It showcases the use of DaisyUI's `shadow-md`, `shadow`, and `shadow-sm` utility classes to apply varying degrees of shadow to each card, enhancing visual depth.

```html
<div class="$$stack">
  <div class="$$card bg-base-200 text-center shadow-md">
    <div class="$$card-body">A</div>
  </div>
  <div class="$$card bg-base-200 text-center shadow">
    <div class="$$card-body">B</div>
  </div>
  <div class="$$card bg-base-200 text-center shadow-sm">
    <div class="$$card-body">C</div>
  </div>
</div>
```

--------------------------------

### Include DaisyUI Themes via CDN Link

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/cdn/+page.md

Demonstrates how to add DaisyUI CSS themes to an HTML document using a `<link>` tag. The first example uses a direct CDN URL for the default themes, while the second shows a templated approach for dynamic theme selection based on a variable.

```HTML
<link href="https://cdn.jsdelivr.net/npm/daisyui@5/themes.css" rel="stylesheet" type="text/css" />
```

```HTML
<link href="{$combinedUrl}" rel="stylesheet" type="text/css" />
```

--------------------------------

### Import Tailwind CSS and daisyUI in PostCSS

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/postcss/+page.md

Defines the main CSS file (`app.css`) to import Tailwind CSS and daisyUI. It also specifies the source files for Tailwind CSS to scan for utility classes, ensuring proper compilation of styles from your HTML and JavaScript.

```postcss
@import "tailwindcss" source(none);
@source "./public/*.{html,js}";
@plugin "daisyui";
```

--------------------------------

### Create a ghost-style select dropdown in DaisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/select/+page.md

This example shows how to apply the `select-ghost` style to a select dropdown, removing its background for a more subtle appearance. It's useful for integrating into designs where a less prominent input is desired.

```html
<select class="$$select $$select-ghost">
  <option disabled selected>Pick a font</option>
  <option>Inter</option>
  <option>Poppins</option>
  <option>Raleway</option>
</select>
```

```jsx
<select defaultValue="Pick a font" class="$$select $$select-ghost">
  <option disabled={true}>Pick a font</option>
  <option>Inter</option>
  <option>Poppins</option>
  <option>Raleway</option>
</select>
```

--------------------------------

### Basic Vertical Divider with Text

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/divider/+page.md

This example demonstrates a standard vertical divider with text 'OR' separating two content blocks. It's suitable for separating elements stacked on top of each other.

```HTML
<div class="flex w-full flex-col">
  <div class="$$card bg-base-300 rounded-box grid h-20 place-items-center">content</div>
  <div class="$$divider">OR</div>
  <div class="$$card bg-base-300 rounded-box grid h-20 place-items-center">content</div>
</div>
```

--------------------------------

### Configure Vite to use Tailwind CSS and React plugins

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/react/+page.md

Modifies the Vite configuration file (`vite.config.js`) to include the Tailwind CSS and React plugins, enabling their functionality within the development server and build process.

```js
import { defineConfig } from "vite";
import tailwindcss from "@tailwindcss/vite";
import react from "@vitejs/plugin-react";

export default defineConfig({
  plugins: [tailwindcss(), react()],
});
```

--------------------------------

### Use a Badge as an Indicator with DaisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/indicator/+page.md

This example shows how to use a DaisyUI badge component as an indicator. A 'New' badge is positioned on the corner of a content block, commonly used for notifications or new items.

```html
<div class="$$indicator">
  <span class="$$indicator-item $$badge $$badge-primary">New</span>
  <div class="bg-base-300 grid h-32 w-32 place-items-center">content</div>
</div>
```

--------------------------------

### Implement DaisyUI Select Component Sizes

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/select/+page.md

Demonstrates how to apply different size variations (extra-small, small, medium, large, extra-large) to the DaisyUI select component using specific utility classes. Examples are provided for both standard HTML and JSX environments.

```HTML
<select class="$$select $$select-xs">
  <option disabled selected>Xsmall</option>
  <option>Xsmall Apple</option>
  <option>Xsmall Orange</option>
  <option>Xsmall Tomato</option>
</select>
<select class="$$select $$select-sm">
  <option disabled selected>Small</option>
  <option>Small Apple</option>
  <option>Small Orange</option>
  <option>Small Tomato</option>
</select>
<select class="$$select $$select-md">
  <option disabled selected>Medium</option>
  <option>Medium Apple</option>
  <option>Medium Orange</option>
  <option>Medium Tomato</option>
</select>
<select class="$$select $$select-lg">
  <option disabled selected>Large</option>
  <option>Large Apple</option>
  <option>Large Orange</option>
  <option>Large Tomato</option>
</select>
<select class="$$select $$select-xl">
  <option disabled selected>Xlarge</option>
  <option>Xlarge Apple</option>
  <option>Xlarge Orange</option>
  <option>Xlarge Tomato</option>
</select>
```

```JSX
<select defaultValue="Xsmall" class="$$select $$select-xs">
  <option disabled={true}>Xsmall</option>
  <option>Xsmall Apple</option>
  <option>Xsmall Orange</option>
  <option>Xsmall Tomato</option>
</select>
<select defaultValue="Small" class="$$select $$select-sm">
  <option disabled={true}>Small</option>
  <option>Small Apple</option>
  <option>Small Orange</option>
  <option>Small Tomato</option>
</select>
<select defaultValue="Medium" class="$$select $$select-md">
  <option disabled={true}>Medium</option>
  <option>Medium Apple</option>
  <option>Medium Orange</option>
  <option>Medium Tomato</option>
</select>
<select defaultValue="Large" class="$$select $$select-lg">
  <option disabled={true}>Large</option>
  <option>Large Apple</option>
  <option>Large Orange</option>
  <option>Large Tomato</option>
</select>
<select defaultValue="Xlarge" class="$$select $$select-xl">
  <option disabled={true}>Xlarge</option>
  <option>Xlarge Apple</option>
  <option>Xlarge Orange</option>
  <option>Xlarge Tomato</option>
</select>
```

--------------------------------

### Configure Deno for Node.js modules

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/fresh/+page.md

Adds the `"nodeModulesDir": "auto"` property to the `deno.json` configuration file. This setting enables Deno to automatically manage and resolve Node.js modules, which is crucial for npm-based dependencies like Tailwind CSS and daisyUI.

```json
{
  "nodeModulesDir": "auto",
  "lock": false

  //...rest of the file

}
```

--------------------------------

### Build Production Assets for DaisyUI Online Store

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/daisyui-nextjs-online-store-template/+page.md

This command optimizes and generates static assets for a DaisyUI online store, preparing it for production deployment. It's a crucial step before deploying the site to a hosting platform.

```bash
npm run build
```

--------------------------------

### Update DaisyUI Card Component Classes

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/upgrade/+page.md

This snippet demonstrates the renaming of `card-bordered` to `card-border` and the removal of `card-compact` in favor of `card-sm` for DaisyUI card components. These changes streamline card styling.

```diff
- <div class="card card-bordered">
+ <div class="card card-border>
```

```diff
- <div class="card card-compact">
+ <div class="card card-sm>
```

--------------------------------

### Add daisyUI to Tailwind CSS configuration

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/what-is-daisyui/+page.md

This JavaScript snippet demonstrates how to include daisyUI as a plugin within your `tailwind.config.js` file. This configuration step is crucial for Tailwind CSS to recognize and process daisyUI's component classes, enabling their use in your project.

```javascript
module.exports = {
  //...
  plugins: [require("daisyui")],
}
```

--------------------------------

### Extend Product Data with metadata.json

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/daisyui-nextjs-online-store-template/+page.md

Example JSON structure for `metadata.json` used to add custom categories, variants, images, and detailed information to Lemon Squeezy product data. This file allows for extensive customization beyond what the Lemon Squeezy dashboard provides.

```json
{
  "id": "12345",
  "availability": true,
  "sale": true,
  "category": ["trending", "bestsellers"],
  "original_price": "$50",
  "variant": {
    "size": [
      { "name": "Small", "link": "https://example.com/small" },
      { "name": "Medium", "link": "https://example.com/medium" }
    ]
  },
  "info": {
    "Material": "100% Cotton",
    "Care Instructions": "Machine washable"
  },
  "images": ["https://example.com/image1.jpg", "https://example.com/image2.jpg"]
}
```

--------------------------------

### daisyUI 4 vs daisyUI 5 Visual Comparison

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/v5/+page.md

A visual comparison demonstrating the design differences between daisyUI version 4 and version 5. This example uses a diff component to highlight visual changes, likely related to component styling or layout.

```html
<figure class="diff aspect-[1600/650] border-2 border-gray-200 rounded-box" data-theme="dark" tabindex="0">
  <div class="diff-item-1" role="img">
    <img class="m-0!" src="https://img.daisyui.com/images/blog/daisyui-4-tailwindcss-components.webp" alt="daisyUI 4"/>
  </div>
  <div class="diff-item-2" role="img" tabindex="0">
    <img class="m-0!" src="https://img.daisyui.com/images/blog/daisyui-5-tailwindcss-components.webp" alt="daisyUI 5"/>
  </div>
  <div class="diff-resizer"></div>
</figure>
<div class="grid [direction:ltr] grid-cols-2 place-items-center tracking-widest text-xs"><span class="text-base-content/40">daisyUI 4</span><span class="text-base-content">daisyUI 5</span></div>
```

--------------------------------

### DaisyUI Input: Text Field with Datalist Suggestions

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/input/+page.md

This example demonstrates how to create an HTML text input field that provides suggestions from a predefined `<datalist>`, all styled consistently with DaisyUI's `input` class. This enhances user experience by offering autocomplete options.

```html
<input type="text" class="$$input" placeholder="Which browser do you use" list="browsers" />
<datalist id="browsers">
  <option value="Chrome"></option>
  <option value="Firefox"></option>
  <option value="Safari"></option>
  <option value="Opera"></option>
  <option value="Edge"></option>
</datalist>
```

--------------------------------

### Include Specific DaisyUI Component with PostCSS

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/v5/+page.md

When using a build process with PostCSS, you can configure daisyUI to include only specific components. This example demonstrates how to include just the 'toggle' component by modifying the PostCSS configuration.

```postcss
@plugin "daisyui" {
  include: toggle;
}
```

--------------------------------

### Integrate daisyUI styles into Lit Shadow DOM

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/lit/+page.md

Modifies a LitElement component (`src/my-element.js`) to import and apply global CSS styles, including Tailwind CSS and daisyUI, within its shadow DOM using `unsafeCSS` for proper encapsulation.

```js
import { LitElement, html } from "lit";
import { unsafeCSS } from "lit";
import globalStyles from "./index.css?inline";

export class MyElement extends LitElement {
  static styles = [unsafeCSS(globalStyles)];
  render() {
    return html`<button class=\"btn\">daisyUI button</button> `;
  }
}

window.customElements.define("my-element", MyElement);
```

--------------------------------

### Responsive Divider Orientation

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/divider/+page.md

This example demonstrates a responsive divider that changes its orientation based on screen size. It's vertical by default and becomes horizontal on large screens (`lg:divider-horizontal`).

```HTML
<div class="flex w-full flex-col lg:flex-row">
  <div class="$$card bg-base-300 rounded-box grid h-32 grow place-items-center">content</div>
  <div class="$$divider lg:$$divider-horizontal">OR</div>
  <div class="$$card bg-base-300 rounded-box grid h-32 grow place-items-center">content</div>
</div>
```

--------------------------------

### Configure Tailwind CSS content and plugins in SvelteKit

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/how-to-install-sveltekit-and-daisyui/+page.md

Modifies the `tailwind.config.js` file to include Svelte files in the content array for JIT compilation and adds the daisyUI plugin. This ensures Tailwind processes styles from Svelte components and daisyUI components are available.

```javascript
/** @type {import('tailwindcss').Config} */
export default {
  content: ['./src/**/*.{html,svelte,js,ts}'],
  theme: {
    extend: {},
  },
  plugins: [require('daisyui')],
}
```

--------------------------------

### Import daisyUI into CSS

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/pages/best-component-library-for-beginners/+page.md

This CSS snippet demonstrates how to import daisyUI into a project's main CSS file. It's a crucial step for daisyUI to apply its styles and components after Tailwind CSS.

```css
@import "tailwindcss";
@plugin "daisyui";
```

--------------------------------

### Info Color Alert Component Example

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/alert/+page.md

Shows an alert component styled with the 'info' color, typically used for informational messages. It includes an SVG icon and a descriptive text, indicating general information or a neutral update.

```HTML
<div role="alert" class="$$alert $$alert-info">
  <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" class="h-6 w-6 shrink-0 stroke-current">
    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M13 16h-1v-4h-1m1-4h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z"></path>
  </svg>
  <span>New software update available.</span>
</div>
```

--------------------------------

### DaisyUI Input: Applying Size Styles

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/input/+page.md

This example illustrates how to adjust the size of HTML input fields (x-small, small, medium, large, x-large) using DaisyUI's `input` class combined with size-specific utility classes like `input-xs`, `input-sm`, etc. This allows for flexible sizing of input elements within your UI.

```html
<input type="text" placeholder="Xsmall" class="$$input $$input-xs" />
<input type="text" placeholder="Small" class="$$input $$input-sm" />
<input type="text" placeholder="Medium" class="$$input $$input-md" />
<input type="text" placeholder="Large" class="$$input $$input-lg" />
<input type="text" placeholder="Xlarge" class="$$input $$input-xl" />
```

--------------------------------

### Warning Color Alert Component Example

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/alert/+page.md

Presents an alert component styled with the 'warning' color, used for caution or potential issues. It includes an SVG icon and a warning message, drawing attention to non-critical problems.

```HTML
<div role="alert" class="$$alert $$alert-warning">
  <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6 shrink-0 stroke-current" fill="none" viewBox="0 0 24 24">
    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 9v2m0 4h.01m-6.938 4h13.856c1.54 0 2.502-1.667 1.732-3L13.732 4c-.77-1.333-2.694-1.333-3.464 0L3.34 16c-.77 1.333.192 3 1.732 3z" />
  </svg>
  <span>Warning: Invalid email address!</span>
</div>
```

--------------------------------

### Center an Indicator on an Image with DaisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/indicator/+page.md

This example demonstrates how to place an indicator badge in the center of an image. A 'Only available for Pro users' badge is centrally positioned, often used for watermarks or feature limitations.

```html
<div class="$$indicator">
  <span class="$$indicator-item $$indicator-center $$indicator-middle">
    Only available for Pro users
  </span>
  <img
    alt="Tailwind CSS examples"
    src="https://img.daisyui.com/images/stock/photo-1606107557195-0e29a4b5b4aa.webp"
  />
</div>
```

--------------------------------

### DaisyUI Nested Submenu

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/menu/+page.md

Provides an example of creating multi-level nested submenus within a DaisyUI menu. This structure is essential for complex navigation systems, allowing users to drill down into more specific categories or options.

```html
<ul class="$$menu bg-base-200 $$rounded-box w-56">
  <li><a>Item 1</a></li>
  <li>
    <a>Parent</a>
    <ul>
      <li><a>Submenu 1</a></li>
      <li><a>Submenu 2</a></li>
      <li>
        <a>Parent</a>
        <ul>
          <li><a>Submenu 1</a></li>
          <li><a>Submenu 2</a></li>
        </ul>
      </li>
    </ul>
  </li>
  <li><a>Item 3</a></li>
</ul>
```

--------------------------------

### Implement DaisyUI Active Buttons

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/button/+page.md

Provides examples for creating active-state buttons in DaisyUI using the `btn-active` class, combined with various color modifiers. These buttons visually appear pressed or highlighted, indicating an active state.

```html
<button class="btn btn-active">Default</button>
<button class="btn btn-active btn-primary">Primary</button>
<button class="btn btn-active btn-secondary">Secondary</button>
<button class="btn btn-active btn-accent">Accent</button>
<button class="btn btn-active btn-info">Info</button>
<button class="btn btn-active btn-success">Success</button>
<button class="btn btn-active btn-warning">Warning</button>
<button class="btn btn-active btn-error">Error</button>
```

--------------------------------

### Configure PostCSS for Tailwind CSS and daisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/bun/+page.md

This `style.css` file imports Tailwind CSS and registers the `daisyui` plugin using PostCSS syntax. This setup allows daisyUI components to be used seamlessly with Tailwind's utility classes.

```postcss
@import "tailwindcss";
@plugin "daisyui";
```

--------------------------------

### Create a Focus-Controlled HTML Collapse Component

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/collapse/+page.md

This example demonstrates a collapse component that opens when focused and closes when focus is lost. It uses `tabindex="0"` to make the `div` focusable, allowing it to respond to focus events for toggling its content.

```html
<div tabindex="0" class="$$collapse bg-base-100 border-base-300 border">
  <div class="$$collapse-title font-semibold">How do I create an account?</div>
  <div class="$$collapse-content text-sm">
    Click the "Sign Up" button in the top right corner and follow the registration process.
  </div>
</div>
```

--------------------------------

### Adjust DaisyUI Stack Component Sizing

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/upgrade/+page.md

This snippet demonstrates a change in how DaisyUI stack components are sized. Instead of applying width and height to individual stack items, the dimensions should now be applied directly to the `stack` container itself.

```diff
- <div class="stack">
-   <div class="card bg-base-100 w-36 h-36">Text</div>
-   <div class="card bg-base-100 w-36 h-36">Text</div>
-   <div class="card bg-base-100 w-36 h-36">Text</div>
+ <div class="stack w-36 h-32">
+   <div class="card bg-base-100">Text</div>
+   <div class="card bg-base-100">Text</div>
+   <div class="card bg-base-100">Text</div>
</div>
```

--------------------------------

### Apply Different Colors to DaisyUI Buttons

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/button/+page.md

Provides examples of applying various semantic color themes (neutral, primary, secondary, accent, info, success, warning, error) to buttons using DaisyUI's color utility classes.

```html
<button class="$$btn $$btn-neutral">Neutral</button>
<button class="$$btn $$btn-primary">Primary</button>
<button class="$$btn $$btn-secondary">Secondary</button>
<button class="$$btn $$btn-accent">Accent</button>
<button class="$$btn $$btn-info">Info</button>
<button class="$$btn $$btn-success">Success</button>
<button class="$$btn $$btn-warning">Warning</button>
<button class="$$btn $$btn-error">Error</button>
```

--------------------------------

### Style Radial Progress with Background and Border

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/radial-progress/+page.md

This example shows how to enhance the radial progress component's appearance by adding a background color, text color, and a border. It uses utility classes like `bg-primary`, `text-primary-content`, and `border-4 border-primary` for comprehensive styling.

```HTML
<div
  class="$$radial-progress bg-primary text-primary-content border-primary border-4"
  style="--$$value:70;" aria-valuenow="70" role="progressbar">
  70%
</div>
```

```JSX
{/* For TSX uncomment the commented types below */}
<div
  className="$$radial-progress bg-primary text-primary-content border-primary border-4"
  style={{ "--$$value": 70 } /* as React.CSSProperties */ } aria-valuenow={70} role="progressbar">
  70%
</div>
```

--------------------------------

### File Input Size Variations

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/file-input/+page.md

Provides examples of different size options for the file input component, ranging from extra small to extra large, achieved by applying specific size classes like 'file-input-xs', 'file-input-sm', 'file-input-md', 'file-input-lg', and 'file-input-xl'.

```HTML
<input type="file" class="$$file-input $$file-input-xs" />

<input type="file" class="$$file-input $$file-input-sm" />

<input type="file" class="$$file-input $$file-input-md" />

<input type="file" class="$$file-input $$file-input-lg" />

<input type="file" class="$$file-input $$file-input-xl" />
```

--------------------------------

### Show Radial Progress with Various Percentage Values

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/radial-progress/+page.md

This example illustrates how to display multiple radial progress components, each set to a different percentage value (0%, 20%, 60%, 80%, 100%). It highlights the flexibility of the `--value` CSS variable for dynamic progress indication.

```HTML
<div class="$$radial-progress" style="--$$value:0;" aria-valuenow="0" role="progressbar">0%</div>
<div class="$$radial-progress" style="--$$value:20;" aria-valuenow="20" role="progressbar">20%</div>
<div class="$$radial-progress" style="--$$value:60;" aria-valuenow="60" role="progressbar">60%</div>
<div class="$$radial-progress" style="--$$value:80;" aria-valuenow="80" role="progressbar">80%</div>
<div class="$$radial-progress" style="--$$value:100;" aria-valuenow="100" role="progressbar">100%</div>
```

```JSX
{/* For TSX uncomment the commented types below */}
<div className="$$radial-progress" style={{"--$$value":0} /* as React.CSSProperties */ }
  aria-valuenow={0} role="progressbar">0%</div>

<div className="$$radial-progress" style={{"--$$value":20} /* as React.CSSProperties */ }
aria-valuenow={20} role="progressbar">20%</div>

<div className="$$radial-progress" style={{"--$$value":60} /* as React.CSSProperties */ }
  aria-valuenow={60} role="progressbar">60%</div>

<div className="$$radial-progress" style={{"--$$value":80} /* as React.CSSProperties */ }
  aria-valuenow={80} role="progressbar">80%</div>

<div className="$$radial-progress" style={{"--$$value":100} /* as React.CSSProperties */ }
  aria-valuenow={100} role="progressbar">100%</div>
```

--------------------------------

### Configure Tailwind CSS plugin in Nuxt Vite

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/nuxt/+page.md

Adds the Tailwind CSS Vite plugin to the Nuxt configuration file (`nuxt.config.ts`) to enable Tailwind CSS processing during development and build, and specifies the main CSS file.

```js
import tailwindcss from "@tailwindcss/vite";
export default defineNuxtConfig({
  vite: {
    plugins: [tailwindcss()],
  },
  css: ["~/assets/app.css"],
});
```

--------------------------------

### DaisyUI HTML File Browser Menu Structure (Partial)

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/menu/+page.md

This HTML snippet demonstrates a hierarchical menu component, likely from DaisyUI, designed to simulate a file system browser. It uses standard HTML `<ul>`, `<li>`, `<a>`, `details`, and `summary` tags for structure and expand/collapse functionality. Embedded SVG icons provide visual representation for files and folders. Note: This snippet is a partial example and may require additional closing tags for full validity.

```html
<ul class="$$menu $$menu-xs bg-base-200 rounded-box max-w-xs w-full">
  <li>
    <a>
      <svg
        xmlns="http://www.w3.org/2000/svg"
        fill="none"
        viewBox="0 0 24 24"
        stroke-width="1.5"
        stroke="currentColor"

```

--------------------------------

### Apply Disabled State to DaisyUI Select Component

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/select/+page.md

Illustrates how to disable a DaisyUI select component, preventing user interaction. This example shows the implementation for both standard HTML and JSX, using the `disabled` attribute.

```HTML
<select class="$$select" disabled>
  <option>You can't touch this</option>
</select>
```

```JSX
<select class="$$select" disabled={true}>
  <option>You can't touch this</option>
</select>
```

--------------------------------

### Customize Astro Blog Hero Section HTML

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/how-to-make-a-blog-quickly-using-astro-and-daisyUI/+page.md

This HTML snippet from `src/components/Hero.astro` defines the structure for the blog's hero section, including the main heading, a badge, and image placeholders. It allows customization of the blog's name, bio, and primary image.

```html
<div class="text-center pt-10">
  <div class="badge badge-outline badge-lg">Hello!</div>
  <h1 class="text-4xl md:text-5xl xl:text-7xl font-semibold brightness-150">
    I'm <span class="text-primary">Antonio,</span>
    <br />
    Digital Marketer & Founder
  </h1>
</div>

<img
  src="/images/antonio.png"
  alt="Antonio"
  class="max-w-xs md:max-w-lg mt-4 absolute"
/>

<img src="/images/bg.png" alt="bg" height="{500}" width="{700}" />
```

--------------------------------

### Implement a Navbar with title and an action icon

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/navbar/+page.md

This example shows a navigation bar featuring a title on the left and an interactive icon button on the right. It uses `flex-1` and `flex-none` for layout distribution and includes an SVG icon within a `btn btn-square btn-ghost` for common actions.

```html
<div class="$$navbar bg-base-100 shadow-sm">
  <div class="flex-1">
    <a class="$$btn $$btn-ghost text-xl">daisyUI</a>
  </div>
  <div class="flex-none">
    <button class="$$btn $$btn-square $$btn-ghost">
      <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" class="inline-block h-5 w-5 stroke-current"> <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M5 12h.01M12 12h.01M19 12h.01M6 12a1 1 0 11-2 0 1 1 0 012 0zm7 0a1 1 0 11-2 0 1 1 0 012 0zm7 0a1 1 0 11-2 0 1 1 0 012 0z"></path> </svg>
    </button>
  </div>
</div>
```

--------------------------------

### Apply Different Sizes to Pagination Buttons in DaisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/pagination/+page.md

This example illustrates how to create pagination components with various button sizes, ranging from extra small (`btn-xs`) to extra large (`btn-xl`). It showcases the application of DaisyUI's size utility classes to individual `btn` elements within separate `join` containers.

```HTML
<div class="join">
  <button class="join-item btn btn-xs">1</button>
  <button class="join-item btn btn-xs btn-active">2</button>
  <button class="join-item btn btn-xs">3</button>
  <button class="join-item btn btn-xs">4</button>
</div>
<div class="join">
  <button class="join-item btn btn-sm">1</button>
  <button class="join-item btn btn-sm btn-active">2</button>
  <button class="join-item btn btn-sm">3</button>
  <button class="join-item btn btn-sm">4</button>
</div>
<div class="join">
  <button class="join-item btn btn-md">1</button>
  <button class="join-item btn btn-md btn-active">2</button>
  <button class="join-item btn btn-md">3</button>
  <button class="join-item btn btn-md">4</button>
</div>
<div class="join">
  <button class="join-item btn btn-lg">1</button>
  <button class="join-item btn btn-lg btn-active">2</button>
  <button class="join-item btn btn-lg">3</button>
  <button class="join-item btn btn-lg">4</button>
</div>
<div class="join">
  <button class="join-item btn btn-xl">1</button>
  <button class="join-item btn btn-xl btn-active">2</button>
  <button class="join-item btn btn-xl">3</button>
  <button class="join-item btn btn-xl">4</button>
</div>
```

--------------------------------

### Tailwind CSS Typography Plugin Demo with daisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/layout-and-typography/+page.md

An extensive HTML example showcasing the application of Tailwind CSS Typography plugin classes in conjunction with daisyUI themes. It demonstrates styling for various HTML elements including headings (H1-H6), paragraphs, bold/italic text, blockquotes, unordered and ordered lists, links, images, and inline code snippets, illustrating how content is visually structured and emphasized.

```HTML
<div class="max-w-3xl my-20">

# Tailwind CSS Typography plugin demo

This is a demo of the Tailwind CSS Typography plugin in action. The plugin provides a set of prose classes that can be used to style your HTML content with minimal effort. When combined with daisyUI, you get access to a variety of themes that are fully compatible with the Typography plugin.

## Headers: Making a Statement

Headers are essential for structuring your content and making it easy to read. With Tailwind CSS Typography and daisyUI, you can create headers that stand out and match your chosen theme.

# The Big Heading, for the Page Title
## Second Heading, for the Page Subtitle
### Third Heading, usually for the Section Title
#### Fourth Heading, usually for the Subsection Title
##### Fifth Heading, for the Subsubsection Title
###### Sixth Heading, for the Paragraph Title

## Text Formatting: Adding Emphasis

Text formatting is crucial for emphasizing important information. Tailwind CSS Typography makes it simple to apply bold, italic, and other text styles.

### Bold and Italic

- **Bold** text is perfect for highlighting key points.
- *Italic* text is great for emphasizing specific words.
- ***Bold and Italic*** text can be used for extra emphasis.

### Blockquotes

Blockquotes are an excellent way to highlight quotes or important information. They are styled beautifully with the Typography plugin.

> "This is a blockquote. It stands out and draws attention to important information. In HTML, blockquotes are created using the `<blockquote>` tag. When used with the Typography plugin and daisyUI, blockquotes receive special styling that includes indentation and a different background color - making quoted text visually distinct from the rest of the content. This styling helps create clear visual hierarchy and improves readability while maintaining semantic HTML markup."

## Lists: Organizing Information

Lists are a great way to organize information in a structured manner. Tailwind CSS Typography makes it easy to create both unordered and ordered lists.

### Unordered Lists

Unordered lists use bullet points to list items. They are perfect for listing items without a specific order.

- First item
- Second item
  - Subitem one
  - Subitem two

### Ordered Lists

Ordered lists use numbers to list items. They are ideal for steps or items that need to be in a specific order.

1. Step one
2. Step two
   1. Substep one
   2. Substep two

## Links and Images: Adding Interactivity

### Links

Links are essential for navigation and adding interactivity to your content. Tailwind CSS Typography ensures that links are styled consistently.

[Visit daisyUI](https://daisyui.com)

### Images

Images are a great way to enhance your content visually. The Typography plugin makes sure they are displayed beautifully.

![Daisy flowers](https://img.daisyui.com/images/stock/photo-1560717789-0ac7c58ac90a.webp)

## Code: Showcasing Your Work

Code snippets are crucial for technical content. Tailwind CSS Typography provides excellent styling for both inline code and code blocks.

### Inline Code

Inline code is perfect for highlighting small pieces of code within a sentence.

Here is an example of inline code: `console.log('Hello, world!');`

### Code Blocks

Code blocks are ideal for displaying larger pieces of code. You can use Shiki, Prism or other libraries for code highlighting.

```javascript
function greet() {
  console.log('Hello, world!');
}
```

</div>
```

--------------------------------

### Remove daisyUI and plugins from Tailwind CSS config

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/upgrade/+page.md

This step removes daisyUI configuration and plugins from `tailwind.config.js` to prepare for the Tailwind CSS upgrade tool. The tool will safely replace the configuration.

```diff
module.exports = {
   content: ['./your-files/**/*.{html,js}'],
   // other stuff...
-  daisyui: {
-    themes: ['light', 'dark', 'cupcake'],
-  },
- plugins: [require("daisyui")],
}
```

--------------------------------

### DaisyUI Horizontal Menu

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/menu/+page.md

This example demonstrates how to transform a standard vertical menu into a horizontal one using DaisyUI's `menu-horizontal` class. This is commonly used for navigation bars at the top of a page or for tab-like interfaces.

```HTML
<ul class="$$menu $$menu-horizontal bg-base-200">
  <li><a>Item 1</a></li>
  <li><a>Item 2</a></li>
  <li><a>Item 3</a></li>
</ul>
```

--------------------------------

### Serve HTML file with Bun dev server

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/bun/+page.md

This command uses Bun to serve the `index.html` file directly from the command line. Bun's built-in dev server handles serving static assets, including the processed CSS, for quick development.

```sh
bun index.html
```

--------------------------------

### Join with Nested and Diverse Elements

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/join/+page.md

Explains that the 'join-item' class applies styling even if it's not a direct child of the 'join' container. This example includes an input, a select dropdown, and a button with an indicator badge, demonstrating complex grouping scenarios.

```HTML
<div class="join">
  <div>
    <div>
      <input class="input join-item w-[5.3rem] md:w-52" placeholder="Search"/>
    </div>
  </div>
  <select class="select join-item w-[5.8rem] md:w-auto">
    <option disabled selected>Filter</option>
    <option>Sci-fi</option>
    <option>Drama</option>
    <option>Action</option>
  </select>
  <div class="indicator">
    <span class="indicator-item badge badge-secondary">new</span>
    <button class="btn join-item">Search</button>
  </div>
</div>
```

--------------------------------

### Displaying Chat Bubbles with Author Images

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/chat/+page.md

This example illustrates how to integrate an author's image into a chat bubble. By combining the `chat-image` and `avatar` classes, you can display a profile picture alongside the chat message, enhancing the conversational context.

```HTML
<div class="$$chat $$chat-start">
  <div class="$$chat-image $$avatar">
    <div class="w-10 rounded-full">
      <img
        alt="Tailwind CSS chat bubble component"
        src="https://img.daisyui.com/images/profile/demo/kenobee@192.webp"
      />
    </div>
  </div>
  <div class="$$chat-bubble">It was said that you would, destroy the Sith, not join them.</div>
</div>
<div class="$$chat $$chat-start">
  <div class="$$chat-image $$avatar">
    <div class="w-10 rounded-full">
      <img
        alt="Tailwind CSS chat bubble component"
        src="https://img.daisyui.com/images/profile/demo/kenobee@192.webp"
      />
    </div>
  </div>
  <div class="$$chat-bubble">It was you who would bring balance to the Force</div>
</div>
<div class="$$chat $$chat-start">
  <div class="$$chat-image $$avatar">
    <div class="w-10 rounded-full">
      <img
        alt="Tailwind CSS chat bubble component"
        src="https://img.daisyui.com/images/profile/demo/kenobee@192.webp"
      />
    </div>
  </div>
  <div class="$$chat-bubble">Not leave it in Darkness</div>
</div>
```

--------------------------------

### Add daisyUI Plugin to WindPress main.css

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/wordpress/+page.md

This snippet shows how to include the daisyUI plugin in your WordPress project's main CSS file. It uses the PostCSS `@plugin` directive, which is processed by the WindPress plugin to integrate daisyUI's styles.

```PostCSS
@plugin "daisyui";
```

--------------------------------

### Apply primary color to a DaisyUI progress bar

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/progress/+page.md

This example shows how to style a progress bar with the DaisyUI 'progress-primary' color. It illustrates different progress values with the primary theme color, suitable for highlighting key actions.

```HTML
<progress class="progress progress-primary w-56" value="0" max="100"></progress>
<progress class="progress progress-primary w-56" value="10" max="100"></progress>
<progress class="progress progress-primary w-56" value="40" max="100"></progress>
<progress class="progress progress-primary w-56" value="70" max="100"></progress>
<progress class="progress progress-primary w-56" value="100" max="100"></progress>
```

--------------------------------

### Configure Vite for Tailwind CSS

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/vike/+page.md

Modify your Vite configuration file to include the Tailwind CSS plugin. This enables Vite to process Tailwind CSS directives during the build process, ensuring styles are correctly applied.

```ts
import tailwindcss from "@tailwindcss/vite";
import vike from "vike/plugin";
import { defineConfig } from "vite";

export default defineConfig({
  plugins: [tailwindcss(), vike()]
});
```

--------------------------------

### Customizing daisyUI Components via CSS with Tailwind's @apply

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/customize/+page.md

This example demonstrates how to apply global customizations to daisyUI components by defining custom CSS rules within a PostCSS file, utilizing Tailwind's `@apply` directive. This method allows for consistent styling across components, here applying `rounded-full` to all elements using the `btn` utility.

```PostCSS
@utility btn {
  @apply rounded-full;
}
```

--------------------------------

### Navbar with Color Variations

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/navbar/+page.md

Illustrates how to apply different background and text colors to DaisyUI navbar components using utility classes. Examples include `bg-neutral`, `text-neutral-content`, `bg-base-300`, `bg-primary`, and `text-primary-content` to achieve distinct visual themes.

```html
<div class="$$navbar bg-neutral text-neutral-content">
  <button class="$$btn $$btn-ghost text-xl">daisyUI</button>
</div>

<div class="$$navbar bg-base-300">
  <button class="$$btn $$btn-ghost text-xl">daisyUI</button>
</div>

<div class="$$navbar bg-primary text-primary-content">
  <button class="$$btn $$btn-ghost text-xl">daisyUI</button>
</div>
```

--------------------------------

### DaisyUI Badge with Dash Style

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/badge/+page.md

Demonstrates various color variations of a DaisyUI badge component styled with the 'dash' modifier, providing visual examples for primary, secondary, accent, info, success, warning, and error contexts.

```html
<div class="$$badge $$badge-dash $$badge-primary">Primary</div>
<div class="$$badge $$badge-dash $$badge-secondary">Secondary</div>
<div class="$$badge $$badge-dash $$badge-accent">Accent</div>
<div class="$$badge $$badge-dash $$badge-info">Info</div>
<div class="$$badge $$badge-dash $$badge-success">Success</div>
<div class="$$badge $$badge-dash $$badge-warning">Warning</div>
<div class="$$badge $$badge-dash $$badge-error">Error</div>
```

--------------------------------

### DaisyUI Toast Centered at Bottom

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/toast/+page.md

This HTML snippet demonstrates how to create a DaisyUI toast component that is positioned at the bottom center of its container. It includes two example alert messages, one for info and one for success.

```html
<div class="$$toast $$toast-center">
  <div class="$$alert $$alert-info">
    <span>New mail arrived.</span>
  </div>
  <div class="$$alert $$alert-success">
    <span>Message sent successfully.</span>
  </div>
</div>
```

--------------------------------

### Build a Navbar with a horizontal menu and submenu

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/navbar/+page.md

This advanced navigation bar example includes a main title and a horizontal menu with a dropdown submenu. It demonstrates the use of daisyUI's `menu`, `menu-horizontal`, and `details` elements to create interactive navigation options for complex site structures.

```html
<div class="$$navbar bg-base-100 shadow-sm">
  <div class="flex-1">
    <a class="$$btn $$btn-ghost text-xl">daisyUI</a>
  </div>
  <div class="flex-none">
    <ul class="$$menu $$menu-horizontal px-1">
      <li><a>Link</a></li>
      <li>
        <details>
          <summary>Parent</summary>
          <ul class="bg-base-100 rounded-t-none p-2">
            <li><a>Link 1</a></li>
            <li><a>Link 2</a></li>
          </ul>
        </details>
      </li>
    </ul>
  </div>
</div>
```

--------------------------------

### Adjust DaisyUI FileInput Border Behavior

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/upgrade/+page.md

This snippet illustrates the change in DaisyUI's `file-input` component where borders are now default. The `file-input-bordered` class is removed, and `file-input-ghost` should be used to remove the default border.

```diff
- <input type="file" class="file-input file-input-bordered">
+ <input type="file" class="file-input">
```

--------------------------------

### Implement URL Input Validation with DaisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/validator/+page.md

This example shows a URL input field with comprehensive validation for a valid URL format using HTML5 `pattern` and DaisyUI's `validator` class. A `validator-hint` confirms the required format to the user.

```HTML
<input type="url" class="$$input $$validator" required placeholder="https://" value="https://"
  pattern="^(https?://)?([a-zA-Z0-9]([a-zA-Z0-9\\-].*[a-zA-Z0-9])?\.)+[a-zA-Z].*$" 
  title="Must be valid URL" />
<p class="$$validator-hint">Must be valid URL</p>
```

--------------------------------

### Build CSS with Tailwind CSS or PostCSS CLI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/npm-init-daisyui/+page.md

These command-line interface (CLI) scripts are used to compile and process CSS files. The Tailwind CSS command generates the final CSS, while the PostCSS command applies PostCSS plugins and transformations, useful for projects without a dedicated bundler.

```Shell
npx tailwindcss -i tailwind.css -o output.css
```

```Shell
npx postcss-cli tailwind.css -o output.css
```

--------------------------------

### Standard Tailwind CSS Button Markup

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/pages/best-component-library-for-beginners/+page.md

This HTML snippet shows the extensive class names required to style a basic button using only Tailwind CSS. It illustrates the verbosity that daisyUI aims to reduce for common UI elements.

```html
<button
  class="rounded-md bg-indigo-600 px-3.5 py-2.5 text-sm font-semibold text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
>
  Click Me
</button>
```

--------------------------------

### Implement Responsive Timeline with DaisyUI and Tailwind CSS

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/timeline/+page.md

This HTML snippet provides the structure for a responsive timeline component. It leverages DaisyUI classes like `timeline-vertical` and `lg:timeline-horizontal` to ensure the timeline stacks vertically on small screens and lays out horizontally on large screens. Each list item represents a timeline event with a start date, a middle icon, and an end description.

```html
<ul class="$$timeline $$timeline-vertical lg:$$timeline-horizontal">
  <li>
    <div class="$$timeline-start">1984</div>
    <div class="$$timeline-middle">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 20 20"
        fill="currentColor"
        class="h-5 w-5"
      >
        <path
          fill-rule="evenodd"
          d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z"
          clip-rule="evenodd"
        />
      </svg>
    </div>
    <div class="$$timeline-end $$timeline-box">First Macintosh computer</div>
    <hr />
  </li>
  <li>
    <hr />
    <div class="$$timeline-start">1998</div>
    <div class="$$timeline-middle">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 20 20"
        fill="currentColor"
        class="h-5 w-5"
      >
        <path
          fill-rule="evenodd"
          d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z"
          clip-rule="evenodd"
        />
      </svg>
    </div>
    <div class="$$timeline-end $$timeline-box">iMac</div>
    <hr />
  </li>
  <li>
    <hr />
    <div class="$$timeline-start">2001</div>
    <div class="$$timeline-middle">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 20 20"
        fill="currentColor"
        class="h-5 w-5"
      >
        <path
          fill-rule="evenodd"
          d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z"
          clip-rule="evenodd"
        />
      </svg>
    </div>
    <div class="$$timeline-end $$timeline-box">iPod</div>
    <hr />
  </li>
  <li>
    <hr />
    <div class="$$timeline-start">2007</div>
    <div class="$$timeline-middle">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 20 20"
        fill="currentColor"
        class="h-5 w-5"
      >
        <path
          fill-rule="evenodd"
          d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z"
          clip-rule="evenodd"
        />
      </svg>
    </div>

```

--------------------------------

### Error Color Alert Component Example

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/alert/+page.md

Displays an alert component styled with the 'error' color, signifying a critical problem or failure. It features an SVG icon and an error message, indicating an issue that requires immediate attention.

```HTML
<div role="alert" class="$$alert $$alert-error">
  <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6 shrink-0 stroke-current" fill="none" viewBox="0 0 24 24">
    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M10 14l2-2m0 0l2-2m-2 2l-2-2m2 2l2 2m7-2a9 9 0 11-18 0 9 9 0 0118 0z" />
  </svg>
  <span>Error! Task failed successfully.</span>
</div>
```

--------------------------------

### Implement a responsive mega menu with nested submenus

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/menu/+page.md

This example illustrates a complex, responsive mega menu featuring multiple top-level items, each with nested submenus. It adapts to different screen sizes using DaisyUI's responsive classes, making it ideal for extensive navigation structures.

```html
<ul class="$$menu xl:$$menu-horizontal bg-base-200 $$rounded-box lg:min-w-max">
  <li>
    <a>Solutions</a>
    <ul>
      <li><a>Design</a></li>
      <li><a>Development</a></li>
      <li><a>Hosting</a></li>
      <li><a>Domain register</a></li>
    </ul>
  </li>
  <li>
    <a>Enterprise</a>
    <ul>
      <li><a>CRM software</a></li>
      <li><a>Marketing management</a></li>
      <li><a>Security</a></li>
      <li><a>Consulting</a></li>
    </ul>
  </li>
  <li>
    <a>Products</a>
    <ul>
      <li><a>UI Kit</a></li>
      <li><a>WordPress themes</a></li>
      <li><a>WordPress plugins</a></li>
      <li>
        <a>Open source</a>
        <ul>
          <li><a>Auth management system</a></li>
          <li><a>VScode theme</a></li>
          <li><a>Color picker app</a></li>
        </ul>
      </li>
    </ul>
  </li>
  <li>
    <a>Company</a>
    <ul>
      <li><a>About us</a></li>
      <li><a>Contact us</a></li>
      <li><a>Privacy policy</a></li>
      <li><a>Press kit</a></li>
    </ul>
  </li>
</ul>
```

--------------------------------

### Create a Navbar with icons at both ends

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/navbar/+page.md

This snippet demonstrates a navigation bar with an icon button at the start (left), a central title, and another icon button at the end (right). It uses `flex-none` for the icon containers and `flex-1` for the title section to manage spacing and alignment.

```html
<div class="$$navbar bg-base-100 shadow-sm">
  <div class="flex-none">
    <button class="$$btn $$btn-square $$btn-ghost">
      <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" class="inline-block h-5 w-5 stroke-current"> <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 6h16M4 12h16M4 18h16"></path> </svg>
    </button>
  </div>
  <div class="flex-1">
    <a class="$$btn $$btn-ghost text-xl">daisyUI</a>
  </div>
  <div class="flex-none">
    <button class="$$btn $$btn-square $$btn-ghost">
      <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" class="inline-block h-5 w-5 stroke-current"> <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M5 12h.01M12 12h.01M19 12h.01M6 12a1 1 0 11-2 0 1 1 0 012 0zm7 0a1 1 0 11-2 0 1 1 0 012 0zm7 0a1 1 0 11-2 0 1 1 0 012 0z"></path> </svg>
    </button>
  </div>
</div>
```

--------------------------------

### Responsive DaisyUI Menu (Vertical to Horizontal)

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/menu/+page.md

This example illustrates how to create a responsive menu that adapts its layout based on screen size. It uses `menu-vertical` for small screens and `lg:menu-horizontal` to switch to a horizontal layout on large screens, leveraging Tailwind CSS's responsive utility classes.

```html
<ul class="$$menu $$menu-vertical lg:$$menu-horizontal bg-base-200 $$rounded-box">
  <li><a>Item 1</a></li>
  <li><a>Item 2</a></li>
  <li><a>Item 3</a></li>
</ul>
```

--------------------------------

### daisyUI Dropdown Menu (No JavaScript)

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/pages/best-component-library-for-beginners/+page.md

This HTML snippet showcases a daisyUI dropdown menu that functions purely with CSS, requiring no JavaScript. This highlights daisyUI's lightweight nature and its benefit for beginners who want to avoid complex scripting.

```html
<!-- A dropdown without JavaScript -->
<div class="dropdown">
  <label tabindex="0" class="btn m-1">Click me</label>
  <ul tabindex="0" class="dropdown-content menu bg-base-100 rounded-box w-52 p-2 shadow">
    <li><a>Item 1</a></li>
    <li><a>Item 2</a></li>
  </ul>
</div>
```

--------------------------------

### Apply secondary color to a DaisyUI progress bar

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/progress/+page.md

This example demonstrates styling a progress bar with the DaisyUI 'progress-secondary' color. It showcases various progress values using the secondary theme color, offering an alternative visual emphasis.

```HTML
<progress class="progress progress-secondary w-56" value="0" max="100"></progress>
<progress class="progress progress-secondary w-56" value="10" max="100"></progress>
<progress class="progress progress-secondary w-56" value="40" max="100"></progress>
<progress class="progress progress-secondary w-56" value="70" max="100"></progress>
<progress class="progress progress-secondary w-56" value="100" max="100"></progress>
```

--------------------------------

### Create Dropdown with HTML details and summary Elements

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/dropdown/+page.md

Demonstrates how to build a simple dropdown using native HTML `<details>` and `<summary>` tags. The dropdown content is toggled by clicking the summary. It can also be controlled programmatically by adding or removing the `open` attribute.

```Structure
  Container for the button + content
              │
              │    button to toggle the visibility of the content
              │                        │
<details>   ──╯                        │
  <summary>open or close</summary>   ──╯
  Content
</details>
```

```html
<details class="$$dropdown">
  <summary class="$$btn m-1">open or close</summary>
  <ul class="$$menu $$dropdown-content bg-base-100 $$rounded-box z-1 w-52 p-2 shadow-sm">
    <li><a>Item 1</a></li>
    <li><a>Item 2</a></li>
  </ul>
</details>
```

--------------------------------

### Rename DaisyUI Tab Component Border and Style Classes

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/upgrade/+page.md

This snippet details the renaming of border and style classes for DaisyUI tab components. `tabs-bordered` is now `tabs-border`, `tabs-lifted` is `tabs-lift`, and `tabs-boxed` is `tabs-box`.

```diff
- <div class="tabs tabs-bordered">
+ <div class="tabs tabs-border>
```

```diff
- <div class="tabs tabs-lifted">
+ <div class="tabs tabs-lift>
```

```diff
- <div class="tabs tabs-boxed">
+ <div class="tabs tabs-box>
```

--------------------------------

### Implement Grouped Radio Inputs with DaisyUI Join

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/pagination/+page.md

This example illustrates how to group multiple radio inputs together using DaisyUI's `join` class. Each radio input is styled as a square button (`btn btn-square`) and becomes a `join-item`, creating a cohesive segmented control for selecting options.

```html
<div class="$$join">
  <input
    class="$$join-item $$btn $$btn-square"
    type="radio"
    name="options"
    aria-label="1"
    checked="checked" />
  <input class="$$join-item $$btn $$btn-square" type="radio" name="options" aria-label="2" />
  <input class="$$join-item $$btn $$btn-square" type="radio" name="options" aria-label="3" />
  <input class="$$join-item $$btn $$btn-square" type="radio" name="options" aria-label="4" />
</div>
```

--------------------------------

### Configure Vite for Tailwind CSS in SvelteKit

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/sveltekit/+page.md

This JavaScript configuration file (`vite.config.js`) integrates Tailwind CSS into your SvelteKit project's build process. It imports the `tailwindcss` plugin and adds it to the Vite `plugins` array alongside `sveltekit()`. This ensures Tailwind CSS is processed during development and build.

```javascript
import tailwindcss from "@tailwindcss/vite";
import { sveltekit } from "@sveltejs/kit/vite";
import { defineConfig } from "vite";

export default defineConfig({
  plugins: [tailwindcss(), sveltekit()]
});
```

--------------------------------

### Apply accent color to a DaisyUI progress bar

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/progress/+page.md

This example illustrates how to style a progress bar with the DaisyUI 'progress-accent' color. It displays different progress values using the accent theme color, providing a distinct visual cue.

```HTML
<progress class="progress progress-accent w-56" value="0" max="100"></progress>
<progress class="progress progress-accent w-56" value="10" max="100"></progress>
<progress class="progress progress-accent w-56" value="40" max="100"></progress>
<progress class="progress progress-accent w-56" value="70" max="100"></progress>
<progress class="progress progress-accent w-56" value="100" max="100"></progress>
```

--------------------------------

### Implement DaisyUI Alert with Outline Style

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/alert/+page.md

This snippet illustrates the usage of DaisyUI's 'outline' style for alert components. It provides examples for various alert types (info, success, warning, error) with a distinct border-only appearance, making the alert content stand out.

```html
<div role="alert" class="$$alert $$alert-info $$alert-outline">
  <span>12 unread messages. Tap to see.</span>
</div>
<div role="alert" class="$$alert $$alert-success $$alert-outline">
  <span>Your purchase has been confirmed!</span>
</div>
<div role="alert" class="$$alert $$alert-warning $$alert-outline">
  <span>Warning: Invalid email address!</span>
</div>
<div role="alert" class="$$alert $$alert-error $$alert-outline">
  <span>Error! Task failed successfully.</span>
</div>
```

--------------------------------

### Implement Pagination with a Disabled Button in DaisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/pagination/+page.md

This example demonstrates how to include a disabled button within a DaisyUI pagination component. The `btn-disabled` class is applied to a button, which is useful for indicating unavailable pages, ellipses, or non-clickable elements in the sequence.

```HTML
<div class="join">
  <button class="join-item btn">1</button>
  <button class="join-item btn">2</button>
  <button class="join-item btn btn-disabled">...</button>
  <button class="join-item btn">99</button>
  <button class="join-item btn">100</button>
</div>
```

--------------------------------

### Update DaisyUI Mockup Phone Internal Classes

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/upgrade/+page.md

This snippet shows the renaming of internal classes within the DaisyUI `mockup-phone` component. `camera` is now `mockup-phone-camera`, `display` is `mockup-phone-display`, and the internal content sizing has changed from `artboard` to explicit `w-[320px] h-[568px]`.

```diff
<div class="mockup-phone">
-  <div class="camera"></div>
+  <div class="mockup-phone-camera"></div>

-    <div class="display">
+    <div class="mockup-phone-display">

-    <div class="artboard artboard-demo phone-1">Hi.</div>
+    <div class="w-[320px] h-[568px]">Hi.</div>
  </div>
</div>
```

--------------------------------

### DaisyUI Responsive Table with Visual Elements

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/table/+page.md

This HTML code demonstrates how to construct a responsive data table using DaisyUI and Tailwind CSS. It includes features like checkboxes, user avatars, and badges within table cells to display rich data. The first example provides a complete table structure with multiple rows, while the second is a partial snippet highlighting the core structure and placeholder classes (e.g., `$$table`) for DaisyUI components.

```HTML
<div class="overflow-x-auto">
  <table class="table">
    <thead>
      <tr>
        <th>
          <label>
            <input type="checkbox" class="checkbox" />
          </label>
        </th>
        <th>Name</th>
        <th>Job</th>
        <th>Favorite Color</th>
        <th></th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <th>
          <label>
            <input type="checkbox" class="checkbox" />
          </label>
        </th>
        <td>
          <div class="flex items-center gap-3">
            <div class="avatar">
              <div class="w-12 h-12 mask mask-squircle">
                <img src="https://img.daisyui.com/images/profile/demo/2@94.webp" alt="Avatar Tailwind CSS Component" />
              </div>
            </div>
            <div>
              <div class="font-bold">Hart Hagerty</div>
              <div class="text-sm opacity-50">United States</div>
            </div>
          </div>
        </td>
        <td>
          Zemlak, Daniel and Leannon
          <br/>
          <span class="badge badge-ghost badge-sm">Desktop Support Technician</span>
        </td>
        <td>Purple</td>
        <th>
          <button class="btn btn-ghost btn-xs">details</button>
        </th>
      </tr>
      <tr>
        <th>
          <label>
            <input type="checkbox" class="checkbox" />
          </label>
        </th>
        <td>
          <div class="flex items-center gap-3">
            <div class="avatar">
              <div class="w-12 h-12 mask mask-squircle">
                <img src="https://img.daisyui.com/images/profile/demo/3@94.webp" alt="Avatar Tailwind CSS Component" />
              </div>
            </div>
            <div>
              <div class="font-bold">Brice Swyre</div>
              <div class="text-sm opacity-50">China</div>
            </div>
          </div>
        </td>
        <td>
          Carroll Group
          <br/>
          <span class="badge badge-ghost badge-sm">Tax Accountant</span>
        </td>
        <td>Red</td>
        <th>
          <button class="btn btn-ghost btn-xs">details</button>
        </th>
      </tr>
      <tr>
        <th>
          <label>
            <input type="checkbox" class="checkbox" />
          </label>
        </th>
        <td>
          <div class="flex items-center gap-3">
            <div class="avatar">
              <div class="w-12 h-12 mask mask-squircle">
                <img src="https://img.daisyui.com/images/profile/demo/4@94.webp" alt="Avatar Tailwind CSS Component" />
              </div>
            </div>
            <div>
              <div class="font-bold">Marjy Ferencz</div>
              <div class="text-sm opacity-50">Russia</div>
            </div>
          </div>
        </td>
        <td>
          Rowe-Schoen
          <br/>
          <span class="badge badge-ghost badge-sm">Office Assistant I</span>
        </td>
        <td>Crimson</td>
        <th>
          <button class="btn btn-ghost btn-xs">details</button>
        </th>
      </tr>
      <tr>
        <th>
          <label>
            <input type="checkbox" class="checkbox" />
          </label>
        </th>
        <td>
          <div class="flex items-center gap-3">
            <div class="avatar">
              <div class="w-12 h-12 mask mask-squircle">
                <img src="https://img.daisyui.com/images/profile/demo/5@94.webp" alt="Avatar Tailwind CSS Component" />
              </div>
            </div>
            <div>
              <div class="font-bold">Yancy Tear</div>
              <div class="text-sm opacity-50">Brazil</div>
            </div>
          </div>
        </td>
        <td>
          Wyman-Ledner
          <br/>
          <span class="badge badge-ghost badge-sm">Community Outreach Specialist</span>
        </td>
        <td>Indigo</td>
        <th>
          <button class="btn btn-ghost btn-xs">details</button>
        </th>
      </tr>
    </tbody>
    <tfoot>
      <tr>
        <th></th>
        <th>Name</th>
        <th>Job</th>
        <th>Favorite Color</th>
        <th></th>
      </tr>
    </tfoot>
  </table>
</div>
```

```HTML
<div class="overflow-x-auto">
  <table class="$$table">
    <!-- head -->
    <thead>
      <tr>
        <th>
          <label>
            <input type="checkbox" class="$$checkbox" />
          </label>
        </th>
        <th>Name</th>
        <th>Job</th>
        <th>Favorite Color</th>
        <th></th>
      </tr>
    </thead>
    <tbody>
      <!-- row 1 -->
      <tr>
        <th>
          <label>
            <input type="checkbox" class="$$checkbox" />
          </label>
        </th>
        <td>
          <div class="flex items-center gap-3">
            <div class="$$avatar">
              <div class="$$mask $$mask-squircle h-12 w-12">
                <img
                  src="https://img.daisyui.com/images/profile/demo/2@94.webp"
                  alt="Avatar Tailwind CSS Component" />
              </div>
```

--------------------------------

### Build CSS with Tailwind CSS CLI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/zola/+page.md

This command uses the Tailwind CSS CLI to process the `input.css` file and generate the final `output.css`. The `--watch` flag enables continuous compilation during development, automatically updating the output file upon changes to the input or source files. For CI/CD, the `--watch` flag should be omitted.

```sh
./static/tailwindcss -i static/input.css -o static/output.css --watch
# For Windows
static\tailwindcss.exe -i static\\input.css -o static\\output.css --watch
```

--------------------------------

### Create Toggleable Icons with Rotate Effect

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/swap/+page.md

This example demonstrates how to implement a toggleable icon using DaisyUI's 'swap' and 'swap-rotate' classes. An invisible checkbox controls the state, switching between two SVG icons (sun and moon) with a rotation animation.

```html
<label class="$$swap $$swap-rotate">
  <!-- this hidden checkbox controls the state -->
  <input type="checkbox" />

  <!-- sun icon -->
  <svg
    class="$$swap-on h-10 w-10 fill-current"
    xmlns="http://www.w3.org/2000/svg"
    viewBox="0 0 24 24">
    <path
      d="M5.64,17l-.71.71a1,1,0,0,0,0,1.41,1,1,0,0,0,1.41,0l.71-.71A1,1,0,0,0,5.64,17ZM5,12a1,1,0,0,0-1-1H3a1,1,0,0,0,0,2H4A1,1,0,0,0,5,12Zm7-7a1,1,0,0,0,1-1V3a1,1,0,0,0-2,0V4A1,1,0,0,0,12,5ZM5.64,7.05a1,1,0,0,0,.7.29,1,1,0,0,0,.71-.29,1,1,0,0,0,0-1.41l-.71-.71A1,1,0,0,0,4.93,6.34Zm12,.29a1,1,0,0,0,.7-.29l.71-.71a1,1,0,1,0-1.41-1.41L17,5.64a1,1,0,0,0,0,1.41A1,1,0,0,0,17.66,7.34ZM21,11H20a1,1,0,0,0,0,2h1a1,1,0,0,0,0-2Zm-9,8a1,1,0,0,0-1,1v1a1,1,0,0,0,2,0V20A1,1,0,0,0,12,19ZM18.36,17A1,1,0,0,0,17,18.36l.71.71a1,1,0,0,0,1.41,0,1,1,0,0,0,0-1.41ZM12,6.5A5.5,5.5,0,1,0,17.5,12,5.51,5.51,0,0,0,12,6.5Zm0,9A3.5,3.5,0,1,1,15.5,12,3.5,3.5,0,0,1,12,15.5Z" />
  </svg>

  <!-- moon icon -->
  <svg
    class="$$swap-off h-10 w-10 fill-current"
    xmlns="http://www.w3.org/2000/svg"
    viewBox="0 0 24 24">
    <path
      d="M21.64,13a1,1,0,0,0-1.05-.14,8.05,8.05,0,0,1-3.37.73A8.15,8.15,0,0,1,9.08,5.49a8.59,8.59,0,0,1,.25-2A1,1,0,0,0,8,2.36,10.14,10.14,0,1,0,22,14.05,1,1,0,0,0,21.64,13Zm-9.5,6.69A8.14,8.14,0,0,1,7.08,5.22v.27A10.15,10.15,0,0,0,17.22,15.63a9.79,9.79,0,0,0,2.1-.22A8.11,8.11,0,0,1,12.14,19.73Z" />
  </svg>
</label>
```

--------------------------------

### HTML for DaisyUI Rating Component Size Examples

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/rating/+page.md

This HTML code demonstrates the implementation of DaisyUI rating components across various sizes: extra-small (xs), small (sm), medium (md), and partially large (lg). Each rating block utilizes specific DaisyUI utility classes like `rating-xs`, `rating-sm`, etc., along with `mask` and `mask-star-2` for styling. The `$$` prefix indicates a placeholder for DaisyUI's class prefixing system, if applicable.

```HTML
<!-- xs -->
<div class="$$rating $$rating-xs">
  <input type="radio" name="rating-5" class="$$mask $$mask-star-2 bg-orange-400" aria-label="1 star" />
  <input type="radio" name="rating-5" class="$$mask $$mask-star-2 bg-orange-400" aria-label="2 star" checked="checked" />
  <input type="radio" name="rating-5" class="$$mask $$mask-star-2 bg-orange-400" aria-label="3 star" />
  <input type="radio" name="rating-5" class="$$mask $$mask-star-2 bg-orange-400" aria-label="4 star" />
  <input type="radio" name="rating-5" class="$$mask $$mask-star-2 bg-orange-400" aria-label="5 star" />
</div>
<!-- sm -->
<div class="$$rating $$rating-sm">
  <input type="radio" name="rating-6" class="$$mask $$mask-star-2 bg-orange-400" aria-label="1 star" />
  <input type="radio" name="rating-6" class="$$mask $$mask-star-2 bg-orange-400" aria-label="2 star" checked="checked" />
  <input type="radio" name="rating-6" class="$$mask $$mask-star-2 bg-orange-400" aria-label="3 star" />
  <input type="radio" name="rating-6" class="$$mask $$mask-star-2 bg-orange-400" aria-label="4 star" />
  <input type="radio" name="rating-6" class="$$mask $$mask-star-2 bg-orange-400" aria-label="5 star" />
</div>
<!-- md -->
<div class="$$rating $$rating-md">
  <input type="radio" name="rating-7" class="$$mask $$mask-star-2 bg-orange-400" aria-label="1 star" />
  <input type="radio" name="rating-7" class="$$mask $$mask-star-2 bg-orange-400" aria-label="2 star" checked="checked" />
  <input type="radio" name="rating-7" class="$$mask $$mask-star-2 bg-orange-400" aria-label="3 star" />
  <input type="radio" name="rating-7" class="$$mask $$mask-star-2 bg-orange-400" aria-label="4 star" />
  <input type="radio" name="rating-7" class="$$mask $$mask-star-2 bg-orange-400" aria-label="5 star" />
</div>
<!-- lg -->
<div class="$$rating $$rating-lg">
  <input type="radio" name="rating-8" class="$$mask $$mask-star-2 bg-orange-400" aria-label="1 star" />
  <input type="radio" name="rating-8" class="$$mask $$mask-star-2 bg-orange-400" aria-label="2 star" checked="checked" />
```

--------------------------------

### Display Avatar Presence Status with DaisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/avatar/+page.md

This example demonstrates how to show online or offline presence indicators on DaisyUI avatars. It uses specific classes (`avatar-online`, `avatar-offline`) to visually communicate a user's current status.

```html
<div class="$$avatar $$avatar-online">
  <div class="w-24 rounded-full">
    <img src="https://img.daisyui.com/images/profile/demo/gordon@192.webp" />
  </div>
</div>
<div class="$$avatar $$avatar-offline">
  <div class="w-24 rounded-full">
    <img src="https://img.daisyui.com/images/profile/demo/idiotsandwich@192.webp" />
  </div>
</div>
```

--------------------------------

### Configure Vite to use Tailwind CSS plugin

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/vite/+page.md

Modifies the Vite configuration file (`vite.config.js`) to include the Tailwind CSS plugin. This step enables Vite to process Tailwind CSS directives and generate the final CSS output.

```js
import { defineConfig } from 'vite';
import tailwindcss from '@tailwindcss/vite';

export default defineConfig({
  plugins: [
    tailwindcss()
  ],
});
```

--------------------------------

### Create Toggleable Content with Flip Effect

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/swap/+page.md

This example illustrates how to use DaisyUI's 'swap' and 'swap-flip' classes to create a toggleable element with a flip animation. Instead of SVG icons, it demonstrates switching between two text-based emojis ('😈' and '😇') controlled by a hidden checkbox.

```html
<label class="$$swap $$swap-flip text-9xl">
  <!-- this hidden checkbox controls the state -->
  <input type="checkbox" />

  <div class="$$swap-on">😈</div>
  <div class="$$swap-off">😇</div>
</label>
```

--------------------------------

### Configure DaisyUI Footer Layout Orientation

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/upgrade/+page.md

This snippet shows how DaisyUI footers are now vertical by default. To achieve a horizontal layout, apply the `footer-horizontal` class, optionally with responsive prefixes like `md:footer-horizontal`.

```diff
- <footer class="footer">
+ <footer class="footer md:footer-horizontal">
```

--------------------------------

### Apply primary color styling to a DaisyUI select dropdown

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/select/+page.md

This example demonstrates how to use the `select-primary` class to style the select dropdown with the theme's primary color. This helps in visually distinguishing important form elements and aligning with brand guidelines.

```html
<select class="$$select $$select-primary">
  <option disabled selected>Pick a text editor</option>
  <option>VScode</option>
  <option>VScode fork</option>
  <option>Another VScode fork</option>
</select>
```

```jsx
<select defaultValue="Pick a text editor" class="$$select $$select-primary">
  <option disabled={true}>Pick a text editor</option>
  <option>VScode</option>
  <option>VScode fork</option>
  <option>Another VScode fork</option>
</select>
```

--------------------------------

### Implement a Responsive Menu with Icons and Badges in DaisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/menu/+page.md

This example showcases a responsive DaisyUI menu that adapts to a horizontal layout on large screens (`lg:menu-horizontal`). It includes menu items with SVG icons and integrates small badges (`badge`, `badge-sm`, `badge-xs`) to display additional information like counts or status, demonstrating dynamic UI elements.

```HTML
<ul class="menu bg-base-200 lg:menu-horizontal rounded-box">
  <li>
    <button>
      <svg xmlns="http://www.w3.org/2000/svg" class="h-5 w-5" fill="none" viewBox="0 0 24 24" stroke="currentColor"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M3 12l2-2m0 0l7-7 7 7M5 10v10a1 1 0 001 1h3m10-11l2 2m-2-2v10a1 1 0 01-1 1h-3m-6 0a1 1 0 001-1v-4a1 1 0 011-1h2a1 1 0 011 1v4a1 1 0 001 1m-6 0h6" /></svg>
      Inbox
      <span class="badge badge-sm">99+</span>
    </button>
  </li>
  <li>
    <button>
      <svg xmlns="http://www.w3.org/2000/svg" class="h-5 w-5" fill="none" viewBox="0 0 24 24" stroke="currentColor"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M13 16h-1v-4h-1m1-4h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z" /></svg>
      Updates
      <span class="badge badge-xs badge-warning">NEW</span>
    </button>
  </li>
  <li>
    <button>
      Stats
      <span class="badge badge-xs badge-info"></span>
    </button>
  </li>
</ul>
```

--------------------------------

### Displaying Avatar Placeholders with DaisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/avatar/+page.md

This HTML snippet provides examples for creating avatar placeholders of different sizes and states using DaisyUI. It showcases how to apply background colors, text colors, rounded shapes, and size utilities to achieve various placeholder designs, including one with an 'online' status.

```HTML
<div class="avatar avatar-placeholder">
  <div class="bg-neutral text-neutral-content w-24 rounded-full">
    <span class="text-3xl">D</span>
  </div>
</div>
<div class="avatar avatar-online avatar-placeholder">
  <div class="bg-neutral text-neutral-content w-16 rounded-full">
    <span class="text-xl">AI</span>
  </div>
</div>
<div class="avatar avatar-placeholder">
  <div class="bg-neutral text-neutral-content w-12 rounded-full">
    <span>SY</span>
  </div>
</div>
<div class="avatar avatar-placeholder">
  <div class="bg-neutral text-neutral-content w-8 rounded-full">
    <span class="text-xs">UI</span>
  </div>
</div>
```

--------------------------------

### Implement DaisyUI Lifted Tabs with Content Below

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/tab/+page.md

This example showcases DaisyUI's 'lifted' tabs where the content area is positioned below the tab navigation. It utilizes radio buttons for tab selection and the `tabs-bottom` class to control the layout, providing a common pattern for tabbed interfaces.

```html
<div class="tabs tabs-bottom tabs-lift w-full my-10 lg:mx-10">
  <input type="radio" name="my_tabs_5" class="tab" aria-label="Tab 1" />
  <div class="tab-content bg-base-100 border-base-300 p-6">Tab content 1</div>
  <input type="radio" name="my_tabs_5" class="tab" aria-label="Tab 2" checked="checked" />
  <div class="tab-content bg-base-100 border-base-300 p-6">Tab content 2</div>
  <input type="radio" name="my_tabs_5" class="tab" aria-label="Tab 3" />
  <div class="tab-content bg-base-100 border-base-300 p-6">Tab content 3</div>
</div>
```

```html
<!-- name of each tab group should be unique -->
<div class="$$tabs $$tabs-lift $$tabs-bottom">
  <input type="radio" name="my_tabs_5" class="$$tab" aria-label="Tab 1" />
  <div class="$$tab-content bg-base-100 border-base-300 p-6">Tab content 1</div>

  <input type="radio" name="my_tabs_5" class="$$tab" aria-label="Tab 2" checked="checked" />
  <div class="$$tab-content bg-base-100 border-base-300 p-6">Tab content 2</div>

  <input type="radio" name="my_tabs_5" class="$$tab" aria-label="Tab 3" />
  <div class="$$tab-content bg-base-100 border-base-300 p-6">Tab content 3</div>
</div>
```

--------------------------------

### Configure PostCSS for Tailwind CSS and daisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/zola/+page.md

This PostCSS configuration file imports Tailwind CSS and includes daisyUI as a plugin. It also specifies the source files (HTML, Markdown templates, and content) that Tailwind CSS should scan for utility classes, enabling proper CSS generation.

```postcss
@import "tailwindcss" source(none);
@source "../templates/*.{html,md}";
@source "../content/*.{html,md}";
@plugin "./daisyui.js";

/* Optional for custom themes – Docs: https://daisyui.com/docs/themes/#how-to-add-a-new-custom-theme */
@plugin "./daisyui-theme.js"{
  /* custom theme here */
}
```

--------------------------------

### Implement DaisyUI Alert with Dash Style

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/alert/+page.md

This snippet shows how to apply DaisyUI's 'dash' style to alert components. It includes examples for info, success, warning, and error alerts, featuring a dashed border design that provides a unique visual cue for notifications.

```html
<div role="alert" class="$$alert $$alert-info $$alert-dash">
  <span>12 unread messages. Tap to see.</span>
</div>
<div role="alert" class="$$alert $$alert-success $$alert-dash">
  <span>Your purchase has been confirmed!</span>
</div>
<div role="alert" class="$$alert $$alert-warning $$alert-dash">
  <span>Warning: Invalid email address!</span>
</div>
<div role="alert" class="$$alert $$alert-error $$alert-dash">
  <span>Error! Task failed successfully.</span>
</div>
```

--------------------------------

### daisyUI Dependencies: Before and After

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/v5/+page.md

Compares the dependency footprint of daisyUI before and after the removal of all external dependencies in version 5. The 'Before' snippet lists several dependencies like culori and postcss-js, indicating a larger package size. The 'After' snippet signifies zero dependencies, highlighting a reduction in package size and potential build time improvements.

```text
Dependencies - Total 1.8 MB on disk (250 files)
  ├╴ culori
  ├╴ picocolors
  ├╴ postcss-js
  │  ╰╴ camelcase-css
  ╰╴ css-selector-tokenizer
     ├╴ cssesc
     ╰╴ fastparse
```

```text
No dependencies - 0 kB
```

--------------------------------

### HTML Structure for a DaisyUI Timeline Component

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/timeline/+page.md

This HTML snippet demonstrates the basic structure for creating a responsive timeline component with alternating start and end points using DaisyUI classes. It utilizes `ul` and `li` elements, along with `div` containers for content and embedded SVG icons for visual markers, providing a clear visual flow for chronological events.

```html
<ul class="timeline">
  <li>
    <div class="timeline-start timeline-box">First Macintosh computer</div>
    <div class="timeline-middle">
      <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor" class="w-5 h-5"><path fill-rule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z" clip-rule="evenodd" /></svg>
    </div>
    <hr/>
  </li>
  <li>
    <hr/>
    <div class="timeline-middle">
      <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor" class="w-5 h-5"><path fill-rule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z" clip-rule="evenodd" /></svg>
    </div>
    <div class="timeline-end timeline-box">iMac</div>
    <hr/>
  </li>
  <li>
    <hr/>
    <div class="timeline-start timeline-box">iPod</div>
    <div class="timeline-middle">
      <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor" class="w-5 h-5"><path fill-rule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z" clip-rule="evenodd" /></svg>
    </div>
    <hr/>
  </li>
  <li>
    <hr/>
    <div class="timeline-middle">
      <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor" class="w-5 h-5"><path fill-rule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z" clip-rule="evenodd" /></svg>
    </div>
    <div class="timeline-end timeline-box">iPhone</div>
    <hr/>
  </li>
  <li>
    <hr/>
    <div class="timeline-start timeline-box">Apple Watch</div>
    <div class="timeline-middle">
      <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor" class="w-5 h-5"><path fill-rule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z" clip-rule="evenodd" /></svg>
    </div>
  </li>
</ul>
```

--------------------------------

### DaisyUI Radio Button with Custom Colors

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/radio/+page.md

Illustrates how to apply custom background, border, and text colors to DaisyUI radio buttons using Tailwind CSS utility classes. This example customizes colors for both normal and checked states.

```html
<input
  type="radio" name="radio-12" checked="checked"
  class="$$radio bg-red-100 border-red-300 checked:bg-red-200 checked:text-red-600 checked:border-red-600" />
<input
  type="radio" name="radio-12" checked="checked"
  class="$$radio bg-blue-100 border-blue-300 checked:bg-blue-200 checked:text-blue-600 checked:border-blue-600" />
```

--------------------------------

### DaisyUI Timeline Component without Icons

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/timeline/+page.md

Demonstrates a basic DaisyUI timeline structure using `ul` and `li` elements to display a chronological sequence of events. This example omits explicit icons for each timeline point, relying on the default styling.

```HTML
<ul class="timeline">
  <li>
    <div class="timeline-start timeline-box">First Macintosh computer</div>
    <hr/>
  </li>
  <li>
    <hr/>
    <div class="timeline-end timeline-box">iMac</div>
    <hr/>
  </li>
  <li>
    <hr/>
    <div class="timeline-start timeline-box">iPod</div>
    <hr/>
  </li>
  <li>
    <hr/>
    <div class="timeline-end timeline-box">iPhone</div>
    <hr/>
  </li>
  <li>
    <hr/>
    <div class="timeline-start timeline-box">Apple Watch</div>
  </li>
</ul>
```

--------------------------------

### DaisyUI Input: Styling a Time Field

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/input/+page.md

This example shows how to apply DaisyUI's default styling to an HTML input field of type `time`. The `input` class ensures a consistent look and feel for time pickers across your application.

```html
<input type="time" class="$$input" />
```

--------------------------------

### Create HTML Table with Hover Highlight using DaisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/table/+page.md

This example shows an HTML table where a row changes its background color on hover, utilizing DaisyUI's `hover:bg-base-300` utility class. This provides immediate visual feedback to the user, indicating interactivity for table rows.

```html
<div class="overflow-x-auto">
  <table class="$$table">
    <!-- head -->
    <thead>
      <tr>
        <th></th>
        <th>Name</th>
        <th>Job</th>
        <th>Favorite Color</th>
      </tr>
    </thead>
    <tbody>
      <!-- row 1 -->
      <tr>
        <th>1</th>
        <td>Cy Ganderton</td>
        <td>Quality Control Specialist</td>
        <td>Blue</td>
      </tr>
      <!-- row 2 -->
      <tr class="hover:bg-base-300">
        <th>2</th>
        <td>Hart Hagerty</td>
        <td>Desktop Support Technician</td>
        <td>Purple</td>
      </tr>
      <!-- row 3 -->
      <tr>
        <th>3</th>
        <td>Brice Swyre</td>
        <td>Tax Accountant</td>
        <td>Red</td>
      </tr>
    </tbody>
  </table>
</div>
```

--------------------------------

### Migrate Bottom Navigation to Dock component

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/upgrade/+page.md

The `bottom-nav` component has been removed and replaced by the `dock` component. Update component classes like `btm-nav-sm` to `dock-sm` and `active` to `dock-active`. Also, `disabled` class should be replaced with `aria-disabled='true'` or `disabled` attribute for better accessibility.

```diff
- <div class="btm-nav btm-nav-sm">
+ <div class="dock dock-sm">
  <button>🏠</button>
-   <button class="active">🍿</button>
+   <button class="dock-active">🍿</button>
  <button>⚙️</button>
</div>
```

--------------------------------

### Integrate Tailwind CSS and daisyUI in PostCSS

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/reactrouter/+page.md

Configures a PostCSS file to import Tailwind CSS and apply the daisyUI plugin. This step is crucial for enabling daisyUI's components and utilities within your project's styling, typically done in a main CSS file like `app.css`.

```postcss
@import "tailwindcss";
@plugin "daisyui";
```

--------------------------------

### Create Stacked Cards with End Direction in DaisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/stack/+page.md

This example demonstrates how to create a stack of cards where new cards are added towards the end of the stack. It utilizes DaisyUI's `stack` and `stack-end` classes to control the stacking direction, along with basic card styling for visual separation.

```html
<div class="$$stack $$stack-end size-28">
  <div class="border-base-content $$card bg-base-100 border text-center">
    <div class="$$card-body">A</div>
  </div>
  <div class="border-base-content $$card bg-base-100 border text-center">
    <div class="$$card-body">B</div>
  </div>
  <div class="border-base-content $$card bg-base-100 border text-center">
    <div class="$$card-body">C</div>
  </div>
</div>
```

--------------------------------

### DaisyUI Skeleton Component

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/static/llms.txt

Documentation for the DaisyUI skeleton component. Used to show a loading state while content is being fetched. Requires utility classes to set its dimensions.

```html
<div class="skeleton"></div>

Rules:
- Add `h-*` and `w-*` utility classes to set height and width.
```

--------------------------------

### Exclude Specific DaisyUI Component with PostCSS

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/v5/+page.md

Conversely, you can exclude specific components from daisyUI using PostCSS configuration. This allows for fine-grained control over which parts of the library are included in your project. This example excludes the 'scrollbar' component.

```postcss
@plugin "daisyui" {
  exclude: scrollbar;
}
```

--------------------------------

### Integrate Icons into DaisyUI Buttons

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/button/+page.md

This example illustrates how to embed SVG icons within DaisyUI buttons. It shows flexible placement options, allowing the icon to appear either before or after the button's text content, enhancing visual communication.

```html
<button class="$$btn">
  <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="2.5" stroke="currentColor" class="size-[1.2em]"><path stroke-linecap="round" stroke-linejoin="round" d="M21 8.25c0-2.485-2.099-4.5-4.688-4.5-1.935 0-3.597 1.126-4.312 2.733-.715-1.607-2.377-2.733-4.313-2.733C5.1 3.75 3 5.765 3 8.25c0 7.22 9 12 9 12s9-4.78 9-12Z" /></svg>
  Like
</button>
<button class="$$btn">
  Like
  <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="2.5" stroke="currentColor" class="size-[1.2em]"><path stroke-linecap="round" stroke-linejoin="round" d="M21 8.25c0-2.485-2.099-4.5-4.688-4.5-1.935 0-3.597 1.126-4.312 2.733-.715-1.607-2.377-2.733-4.313-2.733C5.1 3.75 3 5.765 3 8.25c0 7.22 9 12 9 12s9-4.78 9-12Z" /></svg>
</button>
```

--------------------------------

### Implement Responsive Stats Component with DaisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/stat/+page.md

This example shows a responsive DaisyUI stats component that displays vertically on small screens and horizontally on large screens. It utilizes Tailwind CSS responsive utilities like `lg:stats-horizontal` to adapt its layout.

```html
<div class="$$stats $$stats-vertical lg:$$stats-horizontal shadow">
  <div class="$$stat">
    <div class="$$stat-title">Downloads</div>
    <div class="$$stat-value">31K</div>
    <div class="$$stat-desc">Jan 1st - Feb 1st</div>
  </div>

  <div class="$$stat">
    <div class="$$stat-title">New Users</div>
    <div class="$$stat-value">4,200</div>
    <div class="$$stat-desc">↗︎ 400 (22%)</div>
  </div>

  <div class="$$stat">
    <div class="$$stat-title">New Registers</div>
    <div class="$$stat-value">1,200</div>
    <div class="$$stat-desc">↘︎ 90 (14%)</div>
  </div>
</div>
```

--------------------------------

### DaisyUI Dropdown: Bottom Alignment, End Horizontal

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/dropdown/+page.md

This HTML snippet showcases a DaisyUI dropdown component that opens below its trigger (`dropdown-bottom`) and aligns to the end (right side) of the button horizontally (`dropdown-end`). This setup is useful for right-aligned menus.

```HTML
<div class="$$dropdown $$dropdown-bottom $$dropdown-end">
  <div tabindex="0" role="button" class="$$btn m-1">Click ⬇️</div>
  <ul tabindex="0" class="$$dropdown-content $$menu bg-base-100 rounded-box z-1 w-52 p-2 shadow-sm">
    <li><a>Item 1</a></li>
    <li><a>Item 2</a></li>
  </ul>
</div>
```

--------------------------------

### Include DaisyUI Toggle Component via CDN

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/v5/+page.md

For projects without a build step, like server-side rendered applications or those using HTMX/Alpine.js, you can include specific daisyUI components via CDN. This example shows how to include only the 'toggle' component's CSS.

```css
https://cdn.jsdelivr.net/npm/daisyui@5/components/toggle.css
```

--------------------------------

### Apply secondary color styling to a DaisyUI select dropdown

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/select/+page.md

This example demonstrates how to use the `select-secondary` class to style the select dropdown with the theme's secondary color. This provides another option for visual differentiation of form elements within a design system.

```html
<select class="$$select $$select-secondary">
  <option disabled selected>Pick a language</option>
  <option>Zig</option>
  <option>Go</option>
  <option>Rust</option>
</select>
```

```jsx
<select defaultValue="Pick a language" class="$$select $$select-secondary">
  <option disabled={true}>Pick a language</option>
  <option>Zig</option>
  <option>Go</option>
  <option>Rust</option>
</select>
```

--------------------------------

### Validate Toggle Input with HTML

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/validator/+page.md

This example demonstrates how to apply the 'required' attribute to a checkbox styled as a toggle switch. It ensures the toggle must be activated for form submission. DaisyUI classes provide the toggle styling and hint text.

```html
<input type="checkbox" class="$$toggle $$validator" required title="Required" />
<p class="$$validator-hint">Required</p>
```

--------------------------------

### DaisyUI Timeline Component

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/static/llms.txt

The Timeline component visualizes a sequence of events in chronological order. It provides parts for marking start, middle, and end points, along with modifiers for snapping icons, using boxes, or compact layouts, and supports vertical or horizontal orientation.

```html
<!-- Example structure for timeline -->
<ul class="timeline">
  <li>
    <div class="timeline-start">2024</div>
    <div class="timeline-middle"></div>
    <div class="timeline-end timeline-box">Event 1</div>
  </li>
  <li>
    <div class="timeline-start timeline-box">Event 2</div>
    <div class="timeline-middle"></div>
    <div class="timeline-end">2025</div>
  </li>
</ul>
```

--------------------------------

### Basic Square Skeleton Placeholder in HTML

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/skeleton/+page.md

Demonstrates a simple square skeleton placeholder using DaisyUI's `skeleton` class. This is useful for indicating that a block of content is currently loading.

```html
<div class="skeleton h-32 w-32"></div>
```

--------------------------------

### HTML Structure for a Basic Timeline Component Item

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/timeline/+page.md

This snippet provides the foundational HTML markup for creating a single timeline item. It includes div elements for the start (e.g., year), middle (containing an SVG icon for a marker), and end sections (e.g., event description), designed to be styled with CSS frameworks like DaisyUI using custom `$$timeline-` classes.

```HTML
    <div class="$$timeline-start">2015</div>
    <div class="$$timeline-middle">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 20 20"
        fill="currentColor"
        class="h-5 w-5"
      >
        <path
          fill-rule="evenodd"
          d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z"
          clip-rule="evenodd"
        />
      </svg>
    </div>
    <div class="$$timeline-end $$timeline-box">Apple Watch</div>
  </li>
</ul>
```

--------------------------------

### Implement DaisyUI Radio Tabs with Lift Effect and Content

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/tab/+page.md

Illustrates the creation of interactive tabs using radio buttons with a 'tabs-lift' style, similar to the 'tabs-border' example. Each 'input type="radio"' controls a 'tab-content' div, and a unique 'name' attribute is essential for maintaining distinct tab group behavior. This provides a visually distinct tab presentation.

```html
<!-- name of each tab group should be unique -->
<div class="$$tabs $$tabs-lift">
  <input type="radio" name="my_tabs_3" class="$$tab" aria-label="Tab 1" />
  <div class="$$tab-content bg-base-100 border-base-300 p-6">Tab content 1</div>

  <input type="radio" name="my_tabs_3" class="$$tab" aria-label="Tab 2" checked="checked" />
  <div class="$$tab-content bg-base-100 border-base-300 p-6">Tab content 2</div>

  <input type="radio" name="my_tabs_3" class="$$tab" aria-label="Tab 3" />
  <div class="$$tab-content bg-base-100 border-base-300 p-6">Tab content 3</div>
</div>
```

--------------------------------

### DaisyUI Empty Badge with Various Sizes

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/badge/+page.md

Demonstrates how to create empty DaisyUI badges in different predefined sizes: large (lg), medium (md), small (sm), and extra-small (xs). These examples use the primary color variant.

```html
<div class="$$badge $$badge-primary $$badge-lg"></div>
<div class="$$badge $$badge-primary $$badge-md"></div>
<div class="$$badge $$badge-primary $$badge-sm"></div>
<div class="$$badge $$badge-primary $$badge-xs"></div>
```

--------------------------------

### DaisyUI Button with Spacing Indicators HTML

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/button/design/+page.md

Demonstrates the HTML structure for a DaisyUI button (`btn btn-primary`) with visual indicators showing spacing measurements (e.g., 48px, 16px). This example uses dynamically defined CSS classes from a Svelte script to position and style the indicators relative to the button.

```HTML
<figure class={figure}>
    <div class="relative">
      <button class="btn btn-primary">Button</button>
      <div
        class={`${indicator} start-full top-0 h-full w-12 translate-x-2 flex-row border-s`}>
        <hr class={`${line} h-px w-full border-s`} />
        <div class={`${item} indicator-middle indicator-end`}>48</div>
      </div>
      <div
        class={`${indicator} -bottom-full start-0 h-12 w-4 translate-y-2 flex-col border-t`}>
        <hr class={`${line} h-full w-px border-s`} />
        <div class={`${item} indicator-center indicator-bottom`}>16</div>
      </div>
      <div
        class={`${indicator} -bottom-full end-0 h-12 w-4 translate-y-2 flex-col border-t`}>
        <hr class={`${line} h-full w-px border-s`} />
        <div class={`${item} indicator-center indicator-bottom`}>16</div>
      </div>
    </div>
  </figure>
```

--------------------------------

### DaisyUI mockup-browser Component

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/static/llms.txt

Displays a browser mockup with a toolbar. The toolbar content can be customized, and a URL can be set using a div with the 'input' class.

```html
<div class="mockup-browser">
  <div class="mockup-browser-toolbar">
    {toolbar content}
  </div>
  <div>{CONTENT}</div>
</div>
```

--------------------------------

### DaisyUI Stack Component API Reference

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/stack/+page.md

Documents the core `stack` component class and its modifiers for controlling alignment (top, bottom, start, end) in DaisyUI. These classes are used to visually layer elements on top of each other, providing flexible layout options for overlapping content.

```APIDOC
DaisyUI Stack Component Classes:

.stack
  - Description: Puts the children elements on top of each other.

.stack-top
  - Description: Aligns the children elements to the top.

.stack-bottom
  - Description: Aligns the children elements to the bottom. (Default alignment)

.stack-start
  - Description: Aligns the children elements to the start (horizontally).

.stack-end
  - Description: Aligns the children elements to the end (horizontally).
```

--------------------------------

### Validate Number Input with HTML

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/validator/+page.md

This example shows how to implement number input validation using HTML5 attributes. It restricts the input to a numerical range (1 to 10) and marks the field as required. DaisyUI classes are applied for visual presentation.

```html
<input type="number" class="$$input $$validator" required placeholder="Type a number between 1 to 10" 
min="1" max="10"
  title="Must be between be 1 to 10" />
<p class="$$validator-hint">Must be between be 1 to 10</p>
```

--------------------------------

### HTML for DaisyUI Badges with Status Icons

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/badge/+page.md

This HTML snippet provides examples of DaisyUI badges, each incorporating a different SVG icon to represent various status types (info, success, warning, error). It utilizes DaisyUI's `badge` and `badge-color` classes for styling, along with embedded SVG for the icons. The `$$` prefix indicates DaisyUI class placeholders.

```HTML
<div class="$$badge $$badge-info">
  <svg class="size-[1em]" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24"><g fill="currentColor" stroke-linejoin="miter" stroke-linecap="butt"><circle cx="12" cy="12" r="10" fill="none" stroke="currentColor" stroke-linecap="square" stroke-miterlimit="10" stroke-width="2"></circle><path d="m12,17v-5.5c0-.276-.224-.5-.5-.5h-1.5" fill="none" stroke="currentColor" stroke-linecap="square" stroke-miterlimit="10" stroke-width="2"></path><circle cx="12" cy="7.25" r="1.25" fill="currentColor" stroke-width="2"></circle></g></svg>
  Info
</div>
<div class="$$badge $$badge-success">
  <svg class="size-[1em]" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24"><g fill="currentColor" stroke-linejoin="miter" stroke-linecap="butt"><circle cx="12" cy="12" r="10" fill="none" stroke="currentColor" stroke-linecap="square" stroke-miterlimit="10" stroke-width="2"></circle><polyline points="7 13 10 16 17 8" fill="none" stroke="currentColor" stroke-linecap="square" stroke-miterlimit="10" stroke-width="2"></polyline></g></svg>
  Success
</div>
<div class="$$badge $$badge-warning">
  <svg class="size-[1em]" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 18 18"><g fill="currentColor"><path d="M7.638,3.495L2.213,12.891c-.605,1.048,.151,2.359,1.362,2.359H14.425c1.211,0,1.967-1.31,1.362-2.359L10.362,3.495c-.605-1.048-2.119-1.048-2.724,0Z" fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="1.5"></path><line x1="9" y1="6.5" x2="9" y2="10" fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="1.5"></line><path d="M9,13.569c-.552,0-1-.449-1-1s.448-1,1-1,1,.449,1,1-.448,1-1,1Z" fill="currentColor" data-stroke="none" stroke="none"></path></g></svg>
  Warning
</div>
<div class="$$badge $$badge-error">
  <svg class="size-[1em]" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24"><g fill="currentColor"><rect x="1.972" y="11" width="20.056" height="2" transform="translate(-4.971 12) rotate(-45)" fill="currentColor" stroke-width="0"></rect><path d="m12,23c-6.065,0-11-4.935-11-11S5.935,1,12,1s11,4.935,11,11-4.935,11-11,11Zm0-20C7.038,3,3,7.037,3,12s4.038,9,9,9,9-4.037,9-9S16.962,3,12,3Z" stroke-width="0" fill="currentColor"></path></g></svg>
  Error
</div>
```

--------------------------------

### Stat Component with Icons and Images in HTML

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/stat/+page.md

This example shows how to enhance the Stat component by including figures like SVG icons or user avatars using the `stat-figure` class. It demonstrates multiple stat items within a single `stats` container, showcasing total likes, page views, and task completion with diverse visual elements.

```HTML
<div class="$$stats shadow">
  <div class="$$stat">
    <div class="$$stat-figure text-primary">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        fill="none"
        viewBox="0 0 24 24"
        class="inline-block h-8 w-8 stroke-current"
      >
        <path
          stroke-linecap="round"
          stroke-linejoin="round"
          stroke-width="2"
          d="M4.318 6.318a4.5 4.5 0 000 6.364L12 20.364l7.682-7.682a4.5 4.5 0 00-6.364-6.364L12 7.636l-1.318-1.318a4.5 4.5 0 00-6.364 0z"
        ></path>
      </svg>
    </div>
    <div class="$$stat-title">Total Likes</div>
    <div class="$$stat-value text-primary">25.6K</div>
    <div class="$$stat-desc">21% more than last month</div>
  </div>

  <div class="$$stat">
    <div class="$$stat-figure text-secondary">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        fill="none"
        viewBox="0 0 24 24"
        class="inline-block h-8 w-8 stroke-current"
      >
        <path
          stroke-linecap="round"
          stroke-linejoin="round"
          stroke-width="2"
          d="M13 10V3L4 14h7v7l9-11h-7z"
        ></path>
      </svg>
    </div>
    <div class="$$stat-title">Page Views</div>
    <div class="$$stat-value text-secondary">2.6M</div>
    <div class="$$stat-desc">21% more than last month</div>
  </div>

  <div class="$$stat">
    <div class="$$stat-figure text-secondary">
      <div class="$$avatar $$avatar-online">
        <div class="w-16 rounded-full">
          <img src="https://img.daisyui.com/images/profile/demo/anakeen@192.webp" />
        </div>
      </div>
    </div>
    <div class="$$stat-value">86%</div>
    <div class="$$stat-title">Tasks done</div>
    <div class="$$stat-desc text-secondary">31 tasks remaining</div>
  </div>
</div>
```

--------------------------------

### Displaying Cally Calendar with daisyUI Styles

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/calendar/+page.md

This snippet demonstrates how to integrate the Cally web component to display a calendar, applying daisyUI styles for a consistent look. It includes commented instructions for CDN import and npm installation, along with the HTML structure for the calendar component, styled with daisyUI classes like `bg-base-100`, `border`, `shadow-lg`, and `rounded-box`.

```HTML
<!--
* Import Cally web component from CDN
<script type="module" src="https://unpkg.com/cally"></script>

* Or install as a dependency:
npm i cally
* and import it in JS
import "cally";
-->

<calendar-date class="cally bg-base-100 border border-base-300 shadow-lg rounded-box">
  <svg aria-label="Previous" class="fill-current size-4" slot="previous" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24"><path fill="currentColor" d="M15.75 19.5 8.25 12l7.5-7.5"></path></svg>
  <svg aria-label="Next" class="fill-current size-4" slot="next" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24"><path fill="currentColor" d="m8.25 4.5 7.5 7.5-7.5 7.5"></path></svg>
  <calendar-month></calendar-month>
</calendar-date>
```

--------------------------------

### Create DaisyUI Window Mockup with Background Color

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/mockup-window/+page.md

This HTML snippet shows how to customize a DaisyUI window mockup with a specific background color. It utilizes `mockup-window` along with `bg-base-100` to set a base background, useful for differentiating mockups.

```html
<div class="mockup-window bg-base-100 border border-base-300">
  <div class="grid place-content-center h-80">Hello!</div>
</div>
```

--------------------------------

### DaisyUI Button with Color Indicators HTML

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/button/design/+page.md

Shows the HTML structure for a DaisyUI button (`btn btn-primary`) with visual indicators highlighting its primary and primary-content colors. This example leverages dynamically defined CSS classes for indicator styling and placement, demonstrating how to reference theme colors.

```HTML
<figure class={figure}>
    <div class="relative">
      <button class="btn btn-primary">Button</button>
      <div
        class={`${indicator} start-1 top-1/3 h-16 w-4 translate-y-2 flex-col`}>
        <div class={circle}>
        </div>
        <hr class={`${line} h-full w-px border-s`} />
        <div class={`${item} indicator-center indicator-bottom`}>
          primary
        </div>
      </div>
      <div
        class={`${indicator} -top-7 end-4 h-16 w-4 flex-col`}>
        <hr class={`${line} h-full w-px border-s`} />
        <div class={circle}>
        </div>
        <div class={`${item} indicator-center indicator-top`}>
          primary-content
        </div>
      </div>
    </div>
  </figure>
```

--------------------------------

### Migrate DaisyUI Table Hover Class

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/upgrade/+page.md

This snippet demonstrates the migration of the `hover` class on table rows in DaisyUI. The old `hover` class is removed and replaced with utility classes like `hover:bg-base-300` to apply background colors on hover, providing more flexibility.

```diff
- <tr class="hover">
+ <tr class="hover:bg-base-300">
```

--------------------------------

### Implement a Hamburger Menu Button with Rotate Effect

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/swap/+page.md

This example shows how to create a hamburger menu button that transforms into a close icon when clicked, utilizing DaisyUI's 'btn', 'btn-circle', 'swap', and 'swap-rotate' classes. The transition between the two SVG icons is animated with a rotation effect.

```html
<label class="$$btn $$btn-circle $$swap $$swap-rotate">
  <!-- this hidden checkbox controls the state -->
  <input type="checkbox" />

  <!-- hamburger icon -->
  <svg
    class="$$swap-off fill-current"
    xmlns="http://www.w3.org/2000/svg"
    width="32"
    height="32"
    viewBox="0 0 512 512">
    <path d="M64,384H448V341.33H64Zm0-106.67H448V234.67H64ZM64,128v42.67H448V128Z" />
  </svg>

  <!-- close icon -->
  <svg
    class="$$swap-on fill-current"
    xmlns="http://www.w3.org/2000/svg"
    width="32"
    height="32"
    viewBox="0 0 512 512">
    <polygon
      points="400 145.49 366.51 112 256 222.51 145.49 112 112 145.49 222.51 256 112 366.51 145.49 400 256 289.49 366.51 400 400 366.51 289.49 256 400 145.49" />
  </svg>
</label>
```

--------------------------------

### Filter component without an HTML form

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/filter/+page.md

This example shows an alternative implementation of the filter component for scenarios where a full HTML form cannot be used. It uses a `div` element to group radio buttons and includes a `filter-reset` class for a custom reset mechanism.

```html
<div class="$$filter">
  <input class="$$btn $$filter-reset" type="radio" name="metaframeworks" aria-label="All"/>
  <input class="$$btn" type="radio" name="metaframeworks" aria-label="Sveltekit"/>
  <input class="$$btn" type="radio" name="metaframeworks" aria-label="Nuxt"/>
  <input class="$$btn" type="radio" name="metaframeworks" aria-label="Next.js"/>
</div>
```

--------------------------------

### Create a Default DaisyUI Button

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/button/+page.md

Demonstrates the basic HTML structure for creating a default button using the DaisyUI 'btn' class.

```html
<button class="$$btn">Default</button>
```

--------------------------------

### Creating a button with daisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/daisyui-vs-tailwindui/+page.md

Demonstrates how to create a basic button using daisyUI's component classes. daisyUI simplifies styling by providing pre-defined classes like 'btn', reducing the amount of utility classes needed compared to raw Tailwind CSS.

```html
<button class="btn">Button</button>
```

--------------------------------

### HTML for Scrollable DaisyUI Steps Component

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/steps/+page.md

This HTML snippet provides the structure for a DaisyUI steps component that can scroll horizontally. It includes examples of different step styles (secondary, accent, error, warning, neutral) applied to individual list items within the steps `<ul>`.

```html
<div class="overflow-x-auto">
  <ul class="$$steps">
    <li class="$$step">start</li>
    <li class="$$step $$step-secondary">2</li>
    <li class="$$step $$step-secondary">3</li>
    <li class="$$step $$step-secondary">4</li>
    <li class="$$step">5</li>
    <li class="$$step $$step-accent">6</li>
    <li class="$$step $$step-accent">7</li>
    <li class="$$step">8</li>
    <li class="$$step $$step-error">9</li>
    <li class="$$step $$step-error">10</li>
    <li class="$$step">11</li>
    <li class="$$step">12</li>
    <li class="$$step $$step-warning">13</li>
    <li class="$$step $$step-warning">14</li>
    <li class="$$step">15</li>
    <li class="$$step $$step-neutral">16</li>
    <li class="$$step $$step-neutral">17</li>
    <li class="$$step $$step-neutral">18</li>
    <li class="$$step $$step-neutral">19</li>
    <li class="$$step $$step-neutral">20</li>
    <li class="$$step $$step-neutral">21</li>
    <li class="$$step $$step-neutral">22</li>
    <li class="$$step $$step-neutral">23</li>
    <li class="$$step $$step-neutral">end</li>
  </ul>
</div>
```

--------------------------------

### Customize Astro Landing Page Layout

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/daisyui-astro-tailwind-documentation-template/+page.md

This Astro component defines the structure and content of the landing page. It imports and renders various sub-components like Hero, Features, and CodeBlock to construct the page's layout and content, allowing for extensive customization.

```astro
---
import CodeBlock from "../components/home/CodeBlock.astro";
import Features from "../components/home/Features.astro";
import Hero from "../components/home/Hero.astro";
import Integration from "../components/home/Integration.astro";
import Contributors from "../components/home/Contributors.astro";
import Testimonial from "../components/home/Testimonial.astro";
---

<script>
  import Translate from "$components/Translate.svelte"
</script>

<div>
  <Hero />
  <Features />
  <CodeBlock />
  <Integration />
  <Contributors />
  <Testimonial />
</div>
```

--------------------------------

### Create an Avatar Group with Counter in DaisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/avatar/+page.md

This example shows an avatar group with an additional counter element. It's useful for indicating a large number of participants beyond the visible avatars, using a placeholder avatar with a text overlay like '+99'.

```html
<div class="$$avatar-group -space-x-6">
  <div class="$$avatar">
    <div class="w-12">
      <img src="https://img.daisyui.com/images/profile/demo/batperson@192.webp" />
    </div>
  </div>
  <div class="$$avatar">
    <div class="w-12">
      <img src="https://img.daisyui.com/images/profile/demo/spiderperson@192.webp" />
    </div>
  </div>
  <div class="$$avatar">
    <div class="w-12">
      <img src="https://img.daisyui.com/images/profile/demo/averagebulk@192.webp" />
    </div>
  </div>
  <div class="$$avatar $$avatar-placeholder">
    <div class="bg-neutral text-neutral-content w-12">
      <span>+99</span>
    </div>
  </div>
</div>
```

--------------------------------

### Configure daisyUI 5 Plugin Options in CSS

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/daisyui-5-alpha/+page.md

This CSS block demonstrates how to configure various options for the daisyUI plugin, such as enabling logs, setting the root selector, including/excluding specific components, and defining themes. This allows for fine-grained control over daisyUI's integration.

```css
@plugin "daisyui" {
  logs: true;
  root: ":root";
  include: button, badge, input, card;
  exclude: badge;
  themes: light --default, dark --prefersdark, cupcake;
}
```

--------------------------------

### Display Validation Hint for Email Input with DaisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/validator/+page.md

This example shows how to use both `validator` and `validator-hint` classes for an email input. The hint text appears below the input when the email is invalid, providing immediate feedback. The hint occupies space even when invisible to prevent layout shifts.

```HTML
<input class="$$input $$validator" type="email" required placeholder="mail@site.com" />
<div class="$$validator-hint">Enter valid email address</div>
```

--------------------------------

### DaisyUI Toast Aligned to Bottom End

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/toast/+page.md

This HTML snippet illustrates how to create a DaisyUI toast component positioned at the bottom end (typically bottom-right in LTR layouts) of its container. It contains two example alert messages, one for info and one for success.

```html
<div class="$$toast $$toast-end">
  <div class="$$alert $$alert-info">
    <span>New mail arrived.</span>
  </div>
  <div class="$$alert $$alert-success">
    <span>Message sent successfully.</span>
  </div>
</div>
```

--------------------------------

### DaisyUI Dropdown Component Syntax

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/static/llms.txt

Details multiple HTML syntaxes for creating dropdown menus with DaisyUI, utilizing native `<details>`/`<summary>`, the Popover API, and CSS focus with `tabindex`. It covers class names for content and placement, and explains modifier options.

```html
<!-- Using details and summary -->
<details class="dropdown">
  <summary>Button</summary>
  <ul class="dropdown-content">{CONTENT}</ul>
</details>
```

```html
<!-- Using popover API -->
<button popovertarget="{id}" style="anchor-name:--{anchor}">{button}</button>
<ul class="dropdown-content" popover id="{id}" style="position-anchor:--{anchor}">{CONTENT}</ul>
```

```html
<!-- Using CSS focus -->
<div class="dropdown">
  <div tabindex="0" role="button">Button</div>
  <ul tabindex="0" class="dropdown-content">{CONTENT}</ul>
</div>
```

--------------------------------

### Configure PostCSS for Tailwind CSS and daisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/htmx/+page.md

Configures a PostCSS file (e.g., app.css) to import Tailwind CSS, specify source files for scanning HTML and JavaScript for utility classes, and include the daisyUI plugin. This setup is crucial for Tailwind to generate the necessary CSS.

```postcss
@import "tailwindcss" source(none);
@source "./public/*.{html,js}";
@plugin "daisyui";
```

--------------------------------

### Implement DaisyUI Countdown Component

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/countdown/+page.md

These code examples illustrate how to build a responsive countdown display using DaisyUI and Tailwind CSS. The HTML version provides a direct implementation, while the JSX version is optimized for React, both utilizing CSS custom properties (`--$$value`) for dynamic countdown values and `aria-live` for accessibility.

```html
<div class="grid auto-cols-max grid-flow-col gap-5 text-center">
  <div class="bg-neutral rounded-box text-neutral-content flex flex-col p-2">
    <span class="$$countdown font-mono text-5xl">
      <span style="--$$value:15;" aria-live="polite" aria-label="15">15</span>
    </span>
    days
  </div>
  <div class="bg-neutral rounded-box text-neutral-content flex flex-col p-2">
    <span class="$$countdown font-mono text-5xl">
      <span style="--$$value:10;" aria-live="polite" aria-label="10">10</span>
    </span>
    hours
  </div>
  <div class="bg-neutral rounded-box text-neutral-content flex flex-col p-2">
    <span class="$$countdown font-mono text-5xl">
      <span style="--$$value:24;" aria-live="polite" aria-label="24">24</span>
    </span>
    min
  </div>
  <div class="bg-neutral rounded-box text-neutral-content flex flex-col p-2">
    <span class="$$countdown font-mono text-5xl">
      <span style="--$$value:59;" aria-live="polite" aria-label="59">59</span>
    </span>
    sec
  </div>
</div>
```

```jsx
{/* For TSX uncomment the commented types below */}
<div class="grid grid-flow-col gap-5 text-center auto-cols-max">
  <div class="flex flex-col p-2 bg-neutral rounded-box text-neutral-content">
    <span class="$$countdown font-mono text-5xl">
      <span style={{"--$$value":15} /* as React.CSSProperties */ } aria-live="polite" aria-label={counter}>15</span>
    </span>
    days
  </div>
  <div class="flex flex-col p-2 bg-neutral rounded-box text-neutral-content">
    <span class="$$countdown font-mono text-5xl">
      <span style={{"--$$value":10} /* as React.CSSProperties */ } aria-live="polite" aria-label={counter}>10</span>
    </span>
    hours
  </div>
  <div class="flex flex-col p-2 bg-neutral rounded-box text-neutral-content">
    <span class="$$countdown font-mono text-5xl">
      <span style={{"--$$value":24} /* as React.CSSProperties */ } aria-live="polite" aria-label={counter}>24</span>
    </span>
    min
  </div>
  <div class="flex flex-col p-2 bg-neutral rounded-box text-neutral-content">
    <span class="$$countdown font-mono text-5xl">
      <span style={{"--$$value":59} /* as React.CSSProperties */ } aria-live="polite" aria-label={59}>59</span>
    </span>
    sec
  </div>
</div>
```

--------------------------------

### Create a Multi-colored Heart-shaped Rating

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/rating/+page.md

Demonstrates using the `mask-heart` shape for a rating component and applying different background colors to each individual heart using Tailwind CSS classes. This example also shows how to add spacing between rating items with the `gap-1` utility class.

```HTML
<div class="$$rating gap-1">
  <input type="radio" name="rating-3" class="$$mask $$mask-heart bg-red-400" aria-label="1 star" />
  <input type="radio" name="rating-3" class="$$mask $$mask-heart bg-orange-400" aria-label="2 star" checked="checked" />
  <input type="radio" name="rating-3" class="$$mask $$mask-heart bg-yellow-400" aria-label="3 star" />
  <input type="radio" name="rating-3" class="$$mask $$mask-heart bg-lime-400" aria-label="4 star" />
  <input type="radio" name="rating-3" class="$$mask $$mask-heart bg-green-400" aria-label="5 star" />
</div>
```

--------------------------------

### Basic File Input HTML

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/file-input/+page.md

Demonstrates the fundamental HTML structure for a file input element, applying the base DaisyUI 'file-input' class for styling.

```HTML
<input type="file" class="$$file-input" />
```

--------------------------------

### Configure Vite to use Tailwind CSS and Vue plugins

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/vue/+page.md

Modifies the Vite configuration file (`vite.config.js`) to include the Tailwind CSS and Vue plugins. This step ensures that Vite processes Tailwind CSS directives and Vue components correctly during development and build.

```js
import { defineConfig } from "vite";
import tailwindcss from "@tailwindcss/vite";
import vue from "@vitejs/plugin-vue";

export default defineConfig({
  plugins: [tailwindcss(), vue()]
});
```

--------------------------------

### Add an Arrow Icon to an HTML Collapse Component

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/collapse/+page.md

This example illustrates how to include an arrow icon within the collapse title, providing a clear visual cue for the expandable content. The `collapse-arrow` modifier class is applied to achieve this specific styling.

```html
<div tabindex="0" class="$$collapse $$collapse-arrow bg-base-100 border-base-300 border">
  <div class="$$collapse-title font-semibold">How do I create an account?</div>
  <div class="$$collapse-content text-sm">
    Click the "Sign Up" button in the top right corner and follow the registration process.
  </div>
</div>
```

--------------------------------

### DaisyUI Toast Component Syntax (HTML)

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/static/llms.txt

Demonstrates the HTML syntax for the DaisyUI toast component, used for stacking elements and positioning them on the page. It outlines the base class and available placement modifiers.

```html
<div class="toast {MODIFIER}">{CONTENT}</div>
```

--------------------------------

### DaisyUI Select Component Default Width and Border Changes

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/upgrade/+page.md

This snippet illustrates updates to DaisyUI select components. Selects now have a default width of 20rem, removing the need for `w-full max-w-xs`. Borders are also default, with `select-bordered` removed; use `select-ghost` to remove the border.

```html
<!-- Select with border -->
<select class="select select-bordered">

<!-- Select without border -->
<select class="select">

<!-- Select with consistent width -->
<select class="select w-full max-w-xs">
```

```html
<!-- Select with border -->
<select class="select">

<!-- Select without border -->
<select class="select select-ghost">

<!-- Select with consistent width -->
<select class="select">
```

--------------------------------

### DaisyUI Button with Border Radius Indicator HTML

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/button/design/+page.md

Illustrates the HTML for a DaisyUI button (`btn btn-primary`) with a visual indicator pointing to its border-radius property. This example uses a dynamically defined CSS class for the indicator's styling and positioning, highlighting a specific CSS variable.

```HTML
<figure class={figure}>
    <div class="relative">
      <button class="btn btn-primary">Button</button>
      <div
        class={`${indicator} -start-1 top-1/2 h-12 w-4 translate-y-2 flex-col`}>
        <div class={circle}>
        </div>
        <hr class={`${line} h-full w-px border-s`} />
        <div class={`${item} indicator-center indicator-bottom`}>
          --radius-field
        </div>
      </div>
    </div>
  </figure>
```

--------------------------------

### Create a Carousel with Indicator Buttons using DaisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/carousel/+page.md

This example illustrates a DaisyUI carousel with navigation controlled by indicator buttons. Clicking these buttons uses anchor links to snap the browser view vertically to the corresponding carousel item, providing a simple navigation mechanism.

```html
<div class="carousel w-full">
  <div id="item1" class="carousel-item w-full">
    <img
      src="https://img.daisyui.com/images/stock/photo-1625726411847-8cbb60cc71e6.webp"
      class="w-full" />
  </div>
  <div id="item2" class="carousel-item w-full">
    <img
      src="https://img.daisyui.com/images/stock/photo-1609621838510-5ad474b7d25d.webp"
      class="w-full" />
  </div>
  <div id="item3" class="carousel-item w-full">
    <img
      src="https://img.daisyui.com/images/stock/photo-1414694762283-acccc27bca85.webp"
      class="w-full" />
  </div>
  <div id="item4" class="carousel-item w-full">
    <img
      src="https://img.daisyui.com/images/stock/photo-1665553365602-b2fb8e5d1707.webp"
      class="w-full" />
  </div>
</div>
<div class="flex w-full justify-center gap-2 py-2">
  <a href="#item1" class="btn btn-xs">1</a>
  <a href="#item2" class="btn btn-xs">2</a>
  <a href="#item3" class="btn btn-xs">3</a>
  <a href="#item4" class="btn btn-xs">4</a>
</div>
```

--------------------------------

### Create a responsive collapsible menu using details tag

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/menu/+page.md

This snippet demonstrates a responsive menu that leverages the native HTML `<details>` and `<summary>` tags to create collapsible sections. It includes nested collapsible submenus, all styled effectively with DaisyUI classes, providing an accessible and interactive navigation experience.

```html
<ul class="$$menu lg:$$menu-horizontal bg-base-200 $$rounded-box lg:mb-64">
  <li><a>Item 1</a></li>
  <li>
    <details open>
      <summary>Parent item</summary>
      <ul>
        <li><a>Submenu 1</a></li>
        <li><a>Submenu 2</a></li>
        <li>
          <details open>
            <summary>Parent</summary>
            <ul>
              <li><a>item 1</a></li>
              <li><a>item 2</a></li>
            </ul>
          </details>
        </li>
      </ul>
    </details>
  </li>
  <li><a>Item 3</a></li>
</ul>
```

--------------------------------

### Rename DaisyUI Menu Item State Classes

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/upgrade/+page.md

This snippet details the renaming of state classes for DaisyUI menu items. `disabled` is now `menu-disabled`, `active` is `menu-active`, and `focus` is `menu-focus`. Additionally, vertical menus no longer default to `w-full`.

```diff
- <ul class="menu">
+ <ul class="menu w-full">

-   <li class="disabled"><a>disabled item</a></li>
+   <li class="menu-disabled"><a>disabled item</a></li>

-   <li class="active"><a>active item</a></li>
+   <li class="menu-active"><a>active item</a></li>

-   <li class="focus"><a>focus item</a></li>
+   <li class="menu-focus"><a>focus item</a></li>
</ul>
```

--------------------------------

### daisyUI PostCSS Plugin Configuration Options

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/config/+page.md

Comprehensive documentation for configuring the daisyUI PostCSS plugin. This section details various parameters that control themes, CSS variable scoping, component inclusion/exclusion, class prefixing, and logging behavior.

```APIDOC
Configuration for @plugin "daisyui" { ... }

themes
  Default: "light --default, dark --prefersdark"
  Type: string or comma separated list or 'false' or 'all'
  Description: List of themes to enable. Use 'false' to disable all themes, 'all' to enable all. Flags like '--default' and '--prefersdark' set default and dark mode themes respectively.

root
  Default: ":root"
  Type: string
  Description: The CSS selector where daisyUI CSS variables are applied. Useful for scoping.

include
  Default: (empty)
  Type: comma separated list
  Description: Specifies a whitelist of daisyUI components to include. Only listed components will be styled.

exclude
  Default: (empty)
  Type: comma separated list
  Description: Specifies a blacklist of daisyUI components or styles to exclude. All other parts remain active.

prefix
  Default: ""
  Type: string
  Description: A string prefix to add to all daisyUI utility classes (e.g., 'btn' becomes 'd-btn' with prefix 'd-').

logs
  Default: true
  Type: boolean
  Description: Controls whether daisyUI outputs logs to the console.
```

--------------------------------

### Style Headless UI Dropdown with daisyUI Classes

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/how-to-use-headless-ui-and-daisyui/+page.md

This example shows how to apply daisyUI and Tailwind CSS utility classes to a Headless UI dropdown component in React. It demonstrates adding `btn` to the button and `menu rounded-box bg-base-200 w-52` to the menu items for a styled appearance, combining functionality with design.

```jsx
import { Menu } from "@headlessui/react"

export default function MyDropDown() {
  return (
    <Menu>
      <Menu.Button className="btn">Button</Menu.Button>
      <Menu.Items className="menu rounded-box bg-base-200 w-52">
        <Menu.Item>
          <li>
            <a href="/link">Item 1</a>
          </li>
        </Menu.Item>
        <Menu.Item>
          <li>
            <a href="/link">Item 2</a>
          </li>
        </Menu.Item>
      </Menu.Items>
    </Menu>
  )
}
```

--------------------------------

### DaisyUI Input Component Default Width and Border Changes

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/upgrade/+page.md

This snippet highlights updates to DaisyUI input components. Inputs now have a default width of 20rem, removing the need for `w-full max-w-xs`. Borders are also default, with `input-bordered` removed; use `input-ghost` to remove the border.

```html
<!-- Input with border -->
<input class="input input-bordered"/>

<!-- Input without border -->
<input class="input"/>

<!-- Input with 20rem width -->
<input class="input w-full max-w-xs"/>
```

```html
<!-- Input with border -->
<input class="input"/>

<!-- Input without border -->
<input class="input input-ghost"/>

<!-- Input with consistent width -->
<input class="input"/>
```

--------------------------------

### Integrating DaisyUI Badges into Buttons

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/badge/+page.md

This snippet illustrates how to incorporate DaisyUI badge components within button elements. It shows how to add a small badge (e.g., for notification counts) inside a button, including an example of applying a secondary color style to the badge.

```html
<button class="$$btn">
  Inbox <div class="$$badge $$badge-sm">+99</div>
</button>

<button class="$$btn">
  Inbox <div class="$$badge $$badge-sm $$badge-secondary">+99</div>
</button>
```

--------------------------------

### Implement Username Requirement Validation with DaisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/validator/+page.md

This example shows a username input field with validation for character types (letters, numbers, dash) and length using HTML5 `pattern`, `minlength`, `maxlength`, and DaisyUI's `validator` class. A `validator-hint` provides user guidance on the required format.

```HTML
<input type="text" class="$$input $$validator" required placeholder="Username" 
  pattern="[A-Za-z][A-Za-z0-9\\-]*" minlength="3" maxlength="30" title="Only letters, numbers or dash" />
<p class="$$validator-hint">
  Must be 3 to 30 characters
  <br/>containing only letters, numbers or dash
</p>
```

--------------------------------

### Create a Basic DaisyUI Collapse with Plus/Minus Icon

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/collapse/+page.md

Demonstrates a standard DaisyUI collapse component that expands and collapses with a visual plus/minus icon, suitable for FAQs or expandable content sections. It uses the `collapse-plus` class for the icon.

```html
<div tabindex="0" class="$$collapse $$collapse-plus bg-base-100 border-base-300 border">
  <div class="$$collapse-title font-semibold">How do I create an account?</div>
  <div class="$$collapse-content text-sm">
    Click the "Sign Up" button in the top right corner and follow the registration process.
  </div>
</div>
```

--------------------------------

### Customize Radial Progress Size and Thickness

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/radial-progress/+page.md

This snippet illustrates how to apply custom size and thickness to a radial progress component using CSS custom properties. It shows examples for both direct HTML styling and JSX (React) component styling, demonstrating how to pass `--size` and `--thickness` variables to control the visual dimensions of the progress bar.

```html
<div class="$$radial-progress" style="--$$value:70; --$$size:12rem; --$$thickness: 2px;" aria-valuenow="70" role="progressbar">70%</div>
<div class="$$radial-progress" style="--$$value:70; --$$size:12rem; --$$thickness: 2rem;" aria-valuenow="70" role="progressbar">70%</div>
```

```jsx
{/* For TSX uncomment the commented types below */}
<div className="$$radial-progress"
  style={{ "--$$value": "70", "--$$size": "12rem", "--$$thickness": "2px" } /* as React.CSSProperties */ }
  aria-valuenow={70} role="progressbar">70%</div>

<div className="$$radial-progress"
  style={{ "--$$value": "70", "--$$size": "12rem", "--$$thickness": "2rem" } /* as React.CSSProperties */ }
  aria-valuenow={70} role="progressbar">70%</div>
```

--------------------------------

### Update Sidebar Navigation in Astro

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/daisyui-astro-tailwind-documentation-template/+page.md

This HTML snippet shows the structure of the sidebar navigation component in `src/components/docs/SideBar.astro`. It defines the main drawer, sidebar container, and the site title/logo area, allowing for customization of the documentation's navigation.

```html
<div class="drawer-side z-40 md:border-r md:border-base-content/10">
  <label
    for="my-drawer-2"
    aria-label="close sidebar"
    class="drawer-overlay"
  ></label>
  <aside class="bg-base-100 min-h-screen w-80">
    <div
      class="bg-base-100/90 sticky top-0 z-20 items-center gap-2 px-4 py-2 backdrop-blur lg:flex"
    >
      <a href="/" class="flex-0 btn btn-ghost px-2">
        <h1
          class="text-2xl font-bold bg-clip-text text-transparent bg-linear-to-r from-primary to-primary/50"
        >
          Access Shield{" "}
          <span class="text-sm text-base-content opacity-50">docs</span>
        </h1>
      </a>
    </div>
  </aside>

  <!-- SideBar Code -->
</div>
```

--------------------------------

### DaisyUI mockup-code Component

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/static/llms.txt

Presents a block of code within a box that resembles a code editor. It supports adding prefixes to lines using `data-prefix` and can be enhanced with syntax highlighting libraries.

```html
<div class="mockup-code">
  <pre data-prefix="$"><code>npm i daisyui</code></pre>
</div>
```

--------------------------------

### DaisyUI Navbar with Cart and Profile Dropdowns

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/navbar/+page.md

This HTML snippet showcases a complex DaisyUI navbar structure. It includes a flexible main section, a cart icon with an item indicator and a compact dropdown for cart summary, and an avatar with a profile dropdown menu. The example uses DaisyUI classes for styling and functionality, built on top of Tailwind CSS.

```HTML
<div class="$$navbar bg-base-100 shadow-sm">
  <div class="flex-1">
    <a class="$$btn $$btn-ghost text-xl">daisyUI</a>
  </div>
  <div class="flex-none">
    <div class="$$dropdown $$dropdown-end">
      <div tabindex="0" role="button" class="$$btn $$btn-ghost $$btn-circle">
        <div class="$$indicator">
          <svg xmlns="http://www.w3.org/2000/svg" class="h-5 w-5" fill="none" viewBox="0 0 24 24" stroke="currentColor"> <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M3 3h2l.4 2M7 13h10l4-8H5.4M7 13L5.4 5M7 13l-2.293 2.293c-.63.63-.184 1.707.707 1.707H17m0 0a2 2 0 100 4 2 2 0 000-4zm-8 2a2 2 0 11-4 0 2 2 0 014 0z" /> </svg>
          <span class="$$badge $$badge-sm $$indicator-item">8</span>
        </div>
      </div>
      <div
        tabindex="0"
        class="$$card $$card-compact $$dropdown-content bg-base-100 z-1 mt-3 w-52 shadow">
        <div class="$$card-body">
          <span class="text-lg font-bold">8 Items</span>
          <span class="text-info">Subtotal: $999</span>
          <div class="$$card-actions">
            <button class="$$btn $$btn-primary $$btn-block">View cart</button>
          </div>
        </div>
      </div>
    </div>
    <div class="$$dropdown $$dropdown-end">
      <div tabindex="0" role="button" class="$$btn $$btn-ghost $$btn-circle $$avatar">
        <div class="w-10 rounded-full">
          <img
            alt="Tailwind CSS Navbar component"
            src="https://img.daisyui.com/images/stock/photo-1534528741775-53994a69daeb.webp" />
        </div>
      </div>
      <ul
        tabindex="0"
        class="$$menu $$menu-sm $$dropdown-content bg-base-100 rounded-box z-1 mt-3 w-52 p-2 shadow">
        <li>
          <a class="justify-between">
            Profile
            <span class="$$badge">New</span>
          </a>
        </li>
        <li><a>Settings</a></li>
        <li><a>Logout</a></li>
      </ul>
    </div>
  </div>
</div>
```

--------------------------------

### DaisyUI Horizontal Divider Positioning

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/divider/+page.md

Illustrates how to create horizontal dividers in DaisyUI and control their alignment within a flex container. The example uses `divider-start`, `divider-horizontal`, and `divider-end` classes to place dividers at the beginning, center, and end respectively, useful for visual content separation.

```html
<div class="flex w-full">
  <div class="$$divider $$divider-horizontal $$divider-start">Start</div>
  <div class="$$divider $$divider-horizontal">Default</div>
  <div class="$$divider $$divider-horizontal $$divider-end">End</div>
</div>
```

--------------------------------

### Initialize DaisyUI Theme from Local Storage

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/app.html

This JavaScript snippet attempts to retrieve a theme preference from the user's local storage and apply it to the 'data-theme' attribute of the document's root HTML element. It includes a try-catch block to gracefully handle potential errors, such as security restrictions preventing local storage access.

```javascript
try { document.documentElement.setAttribute("data-theme", localStorage.getItem("theme")) } catch (e) {}
```

--------------------------------

### HTML Fragment for Footer Social Icons

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/footer/+page.md

This snippet contains the SVG path data and surrounding HTML for two social media icons (YouTube and Facebook). It's a fragment, starting mid-attribute and ending with closing `nav` and `footer` tags, indicating its use within a larger HTML footer component.

```HTML
          d="M19.615 3.184c-3.604-.246-11.631-.245-15.23 0-3.897.266-4.356 2.62-4.385 8.816.029 6.185.484 8.549 4.385 8.816 3.6.245 11.626.246 15.23 0 3.897-.266 4.356-2.62 4.385-8.816-.029-6.185-.484-8.549-4.385-8.816zm-10.615 12.816v-8l8 3.993-8 4.007z"></path>
      </svg>
    </a>
    <a>
      <svg
        xmlns="http://www.w3.org/2000/svg"
        width="24"
        height="24"
        viewBox="0 0 24 24"
        class="fill-current">
        <path
          d="M9 8h-3v4h3v12h5v-12h3.642l.358-4h-4v-1.667c0-.955.192-1.333 1.115-1.333h2.885v-5h-3.808c-3.596 0-5.192 1.583-5.192 4.615v3.385z"></path>
      </svg>
    </a>
  </nav>
</footer>
```

--------------------------------

### Responsive Steps Component with Tailwind CSS

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/steps/+page.md

Shows how to create a responsive steps component that adapts its layout from vertical on small screens to horizontal on large screens using Tailwind CSS utility classes like `lg:steps-horizontal`.

```html
<ul class="$$steps $$steps-vertical lg:$$steps-horizontal">
  <li class="$$step $$step-primary">Register</li>
  <li class="$$step $$step-primary">Choose plan</li>
  <li class="$$step">Purchase</li>
  <li class="$$step">Receive Product</li>
</ul>
```

--------------------------------

### Use daisyUI button component in Next.js page

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/install-daisyui-and-tailwindcss-in-nextjs/+page.md

This JSX code demonstrates how to use a daisyUI button component within a Next.js `app/page.tsx` file. It renders a primary button with the text 'Hello daisyUI!', showcasing basic daisyUI integration and styling.

```jsx
export default function Home() {
  return (
    <>
      <button className="btn btn-primary">Hello daisyUI!</button>
    </>
  )
}
```

--------------------------------

### Remove RTL Configuration and tailwindcss-flip Plugin

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/how-to-update-daisyui-4/+page.md

DaisyUI 4 components now natively support LTR/RTL using logical CSS properties, eliminating the need for explicit `rtl: true` configuration and the `tailwindcss-flip` plugin. This snippet shows how to remove these from your `module.exports` configuration, simplifying your project setup for RTL support.

```js
module.exports = {
  //...
  plugins: [require("daisyui"), require("tailwindcss-flip")],
  daisyui: {
    rtl: true,
  },
}
```

```js
module.exports = {
  //...
  plugins: [require("daisyui")],
  daisyui: {},
}
```

--------------------------------

### Display a basic keyboard key using DaisyUI Kbd

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/kbd/+page.md

Demonstrates the fundamental usage of the `kbd` component to display a single keyboard key. This is the simplest form of the component.

```html
<kbd class="$$kbd">K</kbd>
```

--------------------------------

### Horizontal Icon-Only Menu Component in DaisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/menu/+page.md

This example provides the HTML structure for creating a horizontal menu in DaisyUI, featuring icon-only buttons or links. It showcases the use of `menu`, `menu-horizontal`, `bg-base-200`, and `rounded-box` classes to style the menu, with each list item containing an SVG icon for navigation.

```html
<ul class="menu menu-horizontal bg-base-200 rounded-box">
  <li>
    <button>
      <svg xmlns="http://www.w3.org/2000/svg" class="h-5 w-5" fill="none" viewBox="0 0 24 24" stroke="currentColor"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M3 12l2-2m0 0l7-7 7 7M5 10v10a1 1 0 001 1h3m10-11l2 2m-2-2v10a1 1 0 01-1 1h-3m-6 0a1 1 0 001-1v-4a1 1 0 011-1h2a1 1 0 011 1v4a1 1 0 001 1m-6 0h6" /></svg>
    </button>
  </li>
  <li>
    <button>
      <svg xmlns="http://www.w3.org/2000/svg" class="h-5 w-5" fill="none" viewBox="0 0 24 24" stroke="currentColor"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M13 16h-1v-4h-1m1-4h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z" /></svg>
    </button>
  </li>
  <li>
    <button>
      <svg xmlns="http://www.w3.org/2000/svg" class="h-5 w-5" fill="none" viewBox="0 0 24 24" stroke="currentColor"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 19v-6a2 2 0 00-2-2H5a2 2 0 00-2 2v6a2 2 0 002 2h2a2 2 0 002-2zm0 0V9a2 2 0 012-2h2a2 2 0 012 2v10m-6 0a2 2 0 002 2h2a2 2 0 002-2m0 0V5a2 2 0 012-2h2a2 2 0 012 2v14a2 2 0 01-2 2h-2a2 2 0 01-2-2z" /></svg>
    </button>
  </li>
</ul>
```

```html
<ul class="$$menu $$menu-horizontal bg-base-200 $$rounded-box">
  <li>
    <a>
      <svg
        xmlns="http://www.w3.org/2000/svg"
        class="h-5 w-5"
        fill="none"
        viewBox="0 0 24 24"
        stroke="currentColor">
        <path
          stroke-linecap="round"
          stroke-linejoin="round"
          stroke-width="2"
          d="M3 12l2-2m0 0l7-7 7 7M5 10v10a1 1 0 001 1h3m10-11l2 2m-2-2v10a1 1 0 01-1 1h-3m-6 0a1 1 0 001-1v-4a1 1 0 011-1h2a1 1 0 011 1v4a1 1 0 001 1m-6 0h6" />
      </svg>
    </a>
  </li>
  <li>
    <a>
      <svg
        xmlns="http://www.w3.org/2000/svg"
        class="h-5 w-5"
        fill="none"
        viewBox="0 0 24 24"
        stroke="currentColor">
        <path
          stroke-linecap="round"
          stroke-linejoin="round"
          stroke-width="2"
          d="M13 16h-1v-4h-1m1-4h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
      </svg>
    </a>
  </li>
  <li>
    <a>
      <svg
        xmlns="http://www.w3.org/2000/svg"
        class="h-5 w-5"
        fill="none"
        viewBox="0 0 24 24"
        stroke="currentColor">
        <path
          stroke-linecap="round"
          stroke-linejoin="round"
          stroke-width="2"
          d="M9 19v-6a2 2 0 00-2-2H5a2 2 0 00-2 2v6a2 2 0 002 2h2a2 2 0 002-2zm0 0V9a2 2 0 012-2h2a2 2 0 012 2v10m-6 0a2 2 0 002 2h2a2 2 0 002-2m0 0V5a2 2 0 012-2h2a2 2 0 012 2v14a2 2 0 01-2 2h-2a2 2 0 01-2-2z" />
      </svg>
    </a>
  </li>
</ul>
```

--------------------------------

### Create a Small HTML Table with DaisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/table/+page.md

This HTML snippet demonstrates how to create a responsive, small-sized table using DaisyUI's 'table-xs' class. It includes a header, body, and footer, with an overflow wrapper for horizontal scrolling on smaller screens. The table displays sample user data.

```HTML
<div class="overflow-x-auto">
  <table class="table table-xs">
    <thead>
      <tr>
        <th></th>
        <th>Name</th>
        <th>Job</th>
        <th>company</th>
        <th>location</th>
        <th>Last Login</th>
        <th>Favorite Color</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <th>1</th>
        <td>Cy Ganderton</td>
        <td>Quality Control Specialist</td>
        <td>Littel, Schaden and Vandervort</td>
        <td>Canada</td>
        <td>12/16/2020</td>
        <td>Blue</td>
      </tr>
      <tr>
        <th>2</th>
        <td>Hart Hagerty</td>
        <td>Desktop Support Technician</td>
        <td>Zemlak, Daniel and Leannon</td>
        <td>United States</td>
        <td>12/5/2020</td>
        <td>Purple</td>
      </tr>
      <tr>
        <th>3</th>
        <td>Brice Swyre</td>
        <td>Tax Accountant</td>
        <td>Carroll Group</td>
        <td>China</td>
        <td>8/15/2020</td>
        <td>Red</td>
      </tr>
      <tr>
        <th>4</th>
        <td>Marjy Ferencz</td>
        <td>Office Assistant I</td>
        <td>Rowe-Schoen</td>
        <td>Russia</td>
        <td>3/25/2021</td>
        <td>Crimson</td>
      </tr>
      <tr>
        <th>5</th>
        <td>Yancy Tear</td>
        <td>Community Outreach Specialist</td>
        <td>Wyman-Ledner</td>
        <td>Brazil</td>
        <td>5/22/2020</td>
        <td>Indigo</td>
      </tr>
      <tr>
        <th>6</th>
        <td>Irma Vasilik</td>
        <td>Editor</td>
        <td>Wiza, Bins and Emard</td>
        <td>Venezuela</td>
        <td>12/8/2020</td>
        <td>Purple</td>
      </tr>
      <tr>
        <th>7</th>
        <td>Meghann Durtnal</td>
        <td>Staff Accountant IV</td>
        <td>Schuster-Schimmel</td>
        <td>Philippines</td>
        <td>2/17/2021</td>
        <td>Yellow</td>
      </tr>
      <tr>
        <th>8</th>
        <td>Sammy Seston</td>
        <td>Accountant I</td>
        <td>O'Hara, Welch and Keebler</td>
        <td>Indonesia</td>
        <td>5/23/2020</td>
        <td>Crimson</td>
      </tr>
      <tr>
        <th>9</th>
        <td>Lesya Tinham</td>
        <td>Safety Technician IV</td>
        <td>Turner-Kuhlman</td>
        <td>Philippines</td>
        <td>2/21/2021</td>
        <td>Maroon</td>
      </tr>
      <tr>
        <th>10</th>
        <td>Zaneta Tewkesbury</td>
        <td>VP Marketing</td>
        <td>Sauer LLC</td>
        <td>Chad</td>
        <td>6/23/2020</td>
        <td>Green</td>
      </tr>
      <tr>
        <th>11</th>
        <td>Andy Tipple</td>
        <td>Librarian</td>
        <td>Hilpert Group</td>
        <td>Poland</td>
        <td>7/9/2020</td>
        <td>Indigo</td>
      </tr>
      <tr>
        <th>12</th>
        <td>Sophi Biles</td>
        <td>Recruiting Manager</td>
        <td>Gutmann Inc</td>
        <td>Indonesia</td>
        <td>2/12/2021</td>
        <td>Maroon</td>
      </tr>
      <tr>
        <th>13</th>
        <td>Florida Garces</td>
        <td>Web Developer IV</td>
        <td>Gaylord, Pacocha and Baumbach</td>
        <td>Poland</td>
        <td>5/31/2020</td>
        <td>Purple</td>
      </tr>
      <tr>
        <th>14</th>
        <td>Maribeth Popping</td>
        <td>Analyst Programmer</td>
        <td>Deckow-Pouros</td>
        <td>Portugal</td>
        <td>4/27/2021</td>
        <td>Aquamarine</td>
      </tr>
      <tr>
        <th>15</th>
        <td>Moritz Dryburgh</td>
        <td>Dental Hygienist</td>
        <td>Schiller, Cole and Hackett</td>
        <td>Sri Lanka</td>
        <td>8/8/2020</td>
        <td>Crimson</td>
      </tr>
      <tr>
        <th>16</th>
        <td>Reid Semiras</td>
        <td>Teacher</td>
        <td>Sporer, Sipes and Rogahn</td>
        <td>Poland</td>
        <td>7/30/2020</td>
        <td>Green</td>
      </tr>
      <tr>
        <th>17</th>
        <td>Alec Lethby</td>
        <td>Teacher</td>
        <td>Reichel, Glover and Hamill</td>
        <td>China</td>
        <td>2/28/2021</td>
        <td>Khaki</td>
      </tr>
      <tr>
        <th>18</th>
        <td>Aland Wilber</td>
        <td>Quality Control Specialist</td>
        <td>Kshlerin, Rogahn and Swaniawski</td>
        <td>Czech Republic</td>
        <td>9/29/2020</td>
        <td>Purple</td>
      </tr>
      <tr>
        <th>19</th>
        <td>Teddie Duerden</td>
        <td>Staff Accountant III</td>
        <td>Pouros, Ullrich and Windler</td>
        <td>France</td>
        <td>10/27/2020</td>
        <td>Aquamarine</td>
      </tr>
      <tr>
        <th>20</th>
        <td>Lorelei Blackstone</td>
        <td>Data Coordinator</td>
        <td>Witting, Kutch and Greenfelder</td>
        <td>Kazakhstan</td>
        <td>6/3/2020</td>
        <td>Red</td>
      </tr>
    </tbody>
    <tfoot>
      <tr>
        <th></th>
        <th>Name</th>
        <th>Job</th>
        <th>company</th>
        <th>location</th>
        <th>Last Login</th>
        <th>Favorite Color</th>
      </tr>
    </tfoot>
  </table>
</div>
```

--------------------------------

### Customize DaisyUI Toggle Colors with Tailwind CSS

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/toggle/+page.md

Shows how to apply custom colors to a DaisyUI toggle component using Tailwind CSS utility classes. This example modifies the border and background colors for both unchecked and checked states, and also sets the text color when checked.

```HTML
<input
  type="checkbox"
  checked="checked"
  class="$$toggle border-indigo-600 bg-indigo-500 checked:border-orange-500 checked:bg-orange-400 checked:text-orange-800"
/>
```

--------------------------------

### DaisyUI Drawer Always Open on Large Screens

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/drawer/+page.md

This example demonstrates a DaisyUI drawer that remains open and visible on large screens due to the `lg:drawer-open` class. On smaller screens, it functions as a standard togglable drawer, allowing users to open and close the sidebar as needed.

```html
<div class="$$drawer lg:$$drawer-open">
  <input id="my-drawer-2" type="checkbox" class="$$drawer-toggle" />
  <div class="$$drawer-content flex flex-col items-center justify-center">
    <!-- Page content here -->
    <label for="my-drawer-2" class="$$btn $$btn-primary $$drawer-button lg:hidden">
      Open drawer
    </label>
  </div>
  <div class="$$drawer-side">
    <label for="my-drawer-2" aria-label="close sidebar" class="$$drawer-overlay"></label>
    <ul class="$$menu bg-base-200 text-base-content min-h-full w-80 p-4">
      <!-- Sidebar content here -->
      <li><a>Sidebar Item 1</a></li>
      <li><a>Sidebar Item 2</a></li>
    </ul>
  </div>
</div>
```

--------------------------------

### HTML Structure for DaisyUI Swap Component

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/swap/+page.md

This HTML snippet illustrates the basic markup for implementing the DaisyUI `swap` component. It defines the `swap-on` and `swap-off` states within a `swap` container and demonstrates how the `swap-active` class triggers the `swap-on` state, typically controlled programmatically via JavaScript.

```html
<label class="swap text-6xl">
  <div class="swap-on">🥵</div>
  <div class="swap-off">🥶</div>
</label>
<label class="swap swap-active text-6xl">
  <div class="swap-on">🥳</div>
  <div class="swap-off">😭</div>
</label>
```

--------------------------------

### Create a Vertical Carousel with DaisyUI and Tailwind CSS

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/carousel/+page.md

This example demonstrates how to construct a vertical carousel using DaisyUI and Tailwind CSS. The `carousel-vertical` class arranges items vertically, and `h-full` ensures each item occupies the full height of the carousel container, allowing for vertical scrolling.

```html
<div class="$$carousel $$carousel-vertical rounded-box h-96">
  <div class="$$carousel-item h-full">
    <img src="https://img.daisyui.com/images/stock/photo-1559703248-dcaaec9fab78.webp" />
  </div>
  <div class="$$carousel-item h-full">
    <img src="https://img.daisyui.com/images/stock/photo-1565098772267-60af42b81ef2.webp" />
  </div>
  <div class="$$carousel-item h-full">
    <img src="https://img.daisyui.com/images/stock/photo-1572635148818-ef6fd45eb394.webp" />
  </div>
  <div class="$$carousel-item h-full">
    <img src="https://img.daisyui.com/images/stock/photo-1494253109108-2e30c049369b.webp" />
  </div>
  <div class="$$carousel-item h-full">
    <img src="https://img.daisyui.com/images/stock/photo-1550258987-190a2d41a8ba.webp" />
  </div>
  <div class="$$carousel-item h-full">
    <img src="https://img.daisyui.com/images/stock/photo-1559181567-c3190ca9959b.webp" />
  </div>
  <div class="$$carousel-item h-full">
    <img src="https://img.daisyui.com/images/stock/photo-1601004890684-d8cbf643f5f2.webp" />
  </div>
</div>
```

--------------------------------

### Customize DaisyUI Alert Color via CSS/PostCSS

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/utilities/+page.md

Illustrates how to set the `--alert-color` CSS variable for the DaisyUI alert component using a CSS rule. This approach is typically used within a PostCSS setup that includes Tailwind CSS and DaisyUI plugins, allowing for centralized styling.

```css
@import "tailwindcss";
@plugin "daisyui";

.alert {
  --alert-color: blue;
}
```

--------------------------------

### Apply Different Sizes to Radio Buttons in DaisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/radio/+page.md

This example showcases how to apply various predefined sizes (extra small, small, medium, large, extra large) to radio buttons using DaisyUI's size utility classes (e.g., `radio-xs`, `radio-sm`, `radio-md`, `radio-lg`, `radio-xl`). Each size is demonstrated with a checked radio button within a group.

```html
<input type="radio" name="radio-2" class="$$radio $$radio-xs" checked="checked" />
<input type="radio" name="radio-2" class="$$radio $$radio-sm" checked="checked" />
<input type="radio" name="radio-2" class="$$radio $$radio-md" checked="checked" />
<input type="radio" name="radio-2" class="$$radio $$radio-lg" checked="checked" />
<input type="radio" name="radio-2" class="$$radio $$radio-xl" checked="checked" />
```

--------------------------------

### Configure Tailwind CSS and daisyUI in Laravel CSS

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/laravel/+page.md

Modifies the main CSS file (`resources/css/app.css`) to import Tailwind CSS and daisyUI. It also specifies `@source` directives for Tailwind's JIT compilation, ensuring that CSS classes used in Laravel Blade templates, JavaScript files, and even vendor views are correctly scanned and included in the final build.

```css
@import "tailwindcss";

@source "../**/*.blade.php";
@source "../**/*.js";
@source "../../vendor/laravel/framework/src/Illuminate/Pagination/resources/views/*.blade.php";
@source "../../storage/framework/views/*.php";

@plugin "daisyui";
```

--------------------------------

### Implement a Vertical Timeline with DaisyUI HTML

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/timeline/+page.md

This HTML snippet provides the complete structure for a vertical timeline component using DaisyUI. Each list item represents an event, with `$$timeline-start` and `$$timeline-end` classes controlling the position of the event box, `$$timeline-middle` for the marker (SVG icon), and `hr` for the connecting line. This setup allows for a visually distinct and chronological display of events.

```HTML
<ul class="$$timeline $$timeline-vertical">
  <li>
    <div class="$$timeline-start $$timeline-box">First Macintosh computer</div>
    <div class="$$timeline-middle">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 20 20"
        fill="currentColor"
        class="h-5 w-5"
      >
        <path
          fill-rule="evenodd"
          d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z"
          clip-rule="evenodd"
        />
      </svg>
    </div>
    <hr />
  </li>
  <li>
    <hr />
    <div class="$$timeline-middle">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 20 20"
        fill="currentColor"
        class="h-5 w-5"
      >
        <path
          fill-rule="evenodd"
          d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z"
          clip-rule="evenodd"
        />
      </svg>
    </div>
    <div class="$$timeline-end $$timeline-box">iMac</div>
    <hr />
  </li>
  <li>
    <hr />
    <div class="$$timeline-start $$timeline-box">iPod</div>
    <div class="$$timeline-middle">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 20 20"
        fill="currentColor"
        class="h-5 w-5"
      >
        <path
          fill-rule="evenodd"
          d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z"
          clip-rule="evenodd"
        />
      </svg>
    </div>
    <hr />
  </li>
  <li>
    <hr />
    <div class="$$timeline-middle">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 20 20"
        fill="currentColor"
        class="h-5 w-5"
      >
        <path
          fill-rule="evenodd"

```

--------------------------------

### Build CSS with Tailwind CSS Standalone CLI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/standalone/+page.md

Demonstrates how to compile the `input.css` file into `output.css` using the Tailwind CSS standalone CLI. The command includes the `--watch` flag for development, enabling automatic recompilation on file changes, and notes its omission for CI/CD builds.

```sh
./tailwindcss -i input.css -o output.css --watch
```

```sh
# For Windows
tailwindcss.exe -i input.css -o output.css --watch
```

--------------------------------

### Implementing Cally Date Picker with daisyUI Dropdown

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/calendar/+page.md

This example shows how to create a date picker using the Cally web component within a daisyUI dropdown. It demonstrates how to trigger the calendar from a button (`popovertarget`) and update the button's text with the selected date using an `onchange` event handler, styled with daisyUI classes like `input`, `dropdown`, `bg-base-100`, `rounded-box`, and `shadow-lg`.

```HTML
<!--
* Import Cally web component from CDN
<script type="module" src="https://unpkg.com/cally"></script>

* Or install as a dependency:
npm i cally
* and import it in JS
import "cally";
-->

<button popovertarget="cally-popover1" class="input input-border" id="cally1" style="anchor-name:--cally1">
  Pick a date
</button>
<div popover id="cally-popover1" class="dropdown bg-base-100 rounded-box shadow-lg" style="position-anchor:--cally1">
  <calendar-date class="cally" onchange={document.getElementById('cally1').innerText = this.value}>
    <svg aria-label="Previous" class="fill-current size-4" slot="previous" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24"><path d="M15.75 19.5 8.25 12l7.5-7.5"></path></svg>
    <svg aria-label="Next" class="fill-current size-4" slot="next" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24"><path d="m8.25 4.5 7.5 7.5-7.5 7.5"></path></svg>
    <calendar-month></calendar-month>
  </calendar-date>
</div>
```

--------------------------------

### Displaying a Responsive Data Table with DaisyUI Classes

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/table/+page.md

This HTML snippet demonstrates how to create a responsive data table using standard HTML table elements enhanced with DaisyUI utility classes. The `overflow-x-auto` class ensures horizontal scrolling for smaller screens, while `$$table` and `$$table-xs` apply DaisyUI's styling for tables, including a compact 'extra-small' size. It showcases a typical data structure with headers and multiple rows of user information, suitable for displaying tabular data efficiently.

```html
<div class="overflow-x-auto">
  <table class="$$table $$table-xs">
    <thead>
      <tr>
        <th></th>
        <th>Name</th>
        <th>Job</th>
        <th>company</th>
        <th>location</th>
        <th>Last Login</th>
        <th>Favorite Color</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <th>1</th>
        <td>Cy Ganderton</td>
        <td>Quality Control Specialist</td>
        <td>Littel, Schaden and Vandervort</td>
        <td>Canada</td>
        <td>12/16/2020</td>
        <td>Blue</td>
      </tr>
      <tr>
        <th>2</th>
        <td>Hart Hagerty</td>
        <td>Desktop Support Technician</td>
        <td>Zemlak, Daniel and Leannon</td>
        <td>United States</td>
        <td>12/5/2020</td>
        <td>Purple</td>
      </tr>
      <tr>
        <th>3</th>
        <td>Brice Swyre</td>
        <td>Tax Accountant</td>
        <td>Carroll Group</td>
        <td>China</td>
        <td>8/15/2020</td>
        <td>Red</td>
      </tr>
      <tr>
        <th>4</th>
        <td>Marjy Ferencz</td>
        <td>Office Assistant I</td>
        <td>Rowe-Schoen</td>
        <td>Russia</td>
        <td>3/25/2021</td>
        <td>Crimson</td>
      </tr>
      <tr>
        <th>5</th>
        <td>Yancy Tear</td>
        <td>Community Outreach Specialist</td>
        <td>Wyman-Ledner</td>
        <td>Brazil</td>
        <td>5/22/2020</td>
        <td>Indigo</td>
      </tr>
      <tr>
        <th>6</th>
        <td>Irma Vasilik</td>
        <td>Editor</td>
        <td>Wiza, Bins and Emard</td>
        <td>Venezuela</td>
        <td>12/8/2020</td>
        <td>Purple</td>
      </tr>
      <tr>
        <th>7</th>
        <td>Meghann Durtnal</td>
        <td>Staff Accountant IV</td>
        <td>Schuster-Schimmel</td>
        <td>Philippines</td>
        <td>2/17/2021</td>
        <td>Yellow</td>
      </tr>
      <tr>
        <th>8</th>
        <td>Sammy Seston</td>
        <td>Accountant I</td>
        <td>O'Hara, Welch and Keebler</td>
        <td>Indonesia</td>
        <td>5/23/2020</td>
        <td>Crimson</td>
      </tr>
      <tr>
        <th>9</th>
        <td>Lesya Tinham</td>
        <td>Safety Technician IV</td>
        <td>Turner-Kuhlman</td>
        <td>Philippines</td>
        <td>2/21/2021</td>
        <td>Maroon</td>
      </tr>
      <tr>
        <th>10</th>
        <td>Zaneta Tewkesbury</td>
        <td>VP Marketing</td>
        <td>Sauer LLC</td>
        <td>Chad</td>
        <td>6/23/2020</td>
        <td>Green</td>
      </tr>
      <tr>
        <th>11</th>
        <td>Andy Tipple</td>
        <td>Librarian</td>
        <td>Hilpert Group</td>
        <td>Poland</td>
        <td>7/9/2020</td>
        <td>Indigo</td>
      </tr>
      <tr>
        <th>12</th>
        <td>Sophi Biles</td>
        <td>Recruiting Manager</td>
        <td>Gutmann Inc</td>
        <td>Indonesia</td>
        <td>2/12/2021</td>
        <td>Maroon</td>
      </tr>
      <tr>
        <th>13</th>
        <td>Florida Garces</td>
        <td>Web Developer IV</td>
        <td>Gaylord, Pacocha and Baumbach</td>
        <td>Poland</td>
        <td>5/31/2020</td>
        <td>Purple</td>
      </tr>
      <tr>
        <th>14</th>
        <td>Maribeth Popping</td>
        <td>Analyst Programmer</td>
        <td>Deckow-Pouros</td>
        <td>Portugal</td>
        <td>4/27/2021</td>
        <td>Aquamarine</td>
      </tr>
      <tr>
        <th>15</th>
        <td>Moritz Dryburgh</td>
        <td>Dental Hygienist</td>
        <td>Schiller, Cole and Hackett</td>
        <td>Sri Lanka</td>
        <td>8/8/2020</td>
        <td>Crimson</td>
      </tr>
      <tr>
        <th>16</th>
        <td>Reid Semiras</td>
        <td>Teacher</td>
        <td>Sporer, Sipes and Rogahn</td>
        <td>Poland</td>
        <td>7/30/2020</td>
        <td>Green</td>
      </tr>
      <tr>
        <th>17</th>
        <td>Alec Lethby</td>
        <td>Teacher</td>
        <td>Reichel, Glover and Hamill</td>
        <td>China</td>
        <td>2/28/2021</td>
        <td>Khaki</td>
      </tr>
      <tr>
        <th>18</th>
        <td>Aland Wilber</td>
        <td>Quality Control Specialist</td>
        <td>Kshlerin, Rogahn and Swaniawski</td>
        <td>Czech Republic</td>
        <td>9/29/2020</td>
        <td>Purple</td>
      </tr>
      <tr>
        <th>19</th>
        <td>Teddie Duerden</td>
        <td>Staff Accountant III</td>
        <td>Pouros, Ullrich and Windler</td>
        <td>France</td>
        <td>10/27/2020</td>
        <td>Aquamarine</td>
      </tr>
      <tr>
        <th>20</th>
        <td>Lorelei Blackstone</td>
        <td>Data Coordiator</td>
        <td>Witting, Kutch and Greenfelder</td>
        <td>Kazakhstan</td>
        <td>6/3/2020</td>
        <td>Red</td>
      </tr>
    </tbody>
    <tfoot>
      <tr>
        <th></th>
        <th>Name</th>
        <th>Job</th>
        <th>company</th>
        <th>location</th>
        <th>Last Login</th>
      </tr>
    </tfoot>
  </table>
</div>
```

--------------------------------

### HTML Timeline Component with Icons

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/timeline/+page.md

This HTML snippet demonstrates how to create a vertical timeline component using a structure that supports text on both sides and an icon in the middle. Each timeline item includes a start point (e.g., date), a middle point with an SVG icon, and an end point (e.g., event description), separated by horizontal rules.

```html
<ul class="$$timeline">
  <li>
    <div class="$$timeline-start">1984</div>
    <div class="$$timeline-middle">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 20 20"
        fill="currentColor"
        class="h-5 w-5"
      >
        <path
          fill-rule="evenodd"
          d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z"
          clip-rule="evenodd"
        />
      </svg>
    </div>
    <div class="$$timeline-end $$timeline-box">First Macintosh computer</div>
    <hr />
  </li>
  <li>
    <hr />
    <div class="$$timeline-start">1998</div>
    <div class="$$timeline-middle">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 20 20"
        fill="currentColor"
        class="h-5 w-5"
      >
        <path
          fill-rule="evenodd"
          d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z"
          clip-rule="evenodd"
        />
      </svg>
    </div>
    <div class="$$timeline-end $$timeline-box">iMac</div>
    <hr />
  </li>
  <li>
    <hr />
    <div class="$$timeline-start">2001</div>
    <div class="$$timeline-middle">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 20 20"
        fill="currentColor"
        class="h-5 w-5"
      >
        <path
          fill-rule="evenodd"
          d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z"
          clip-rule="evenodd"
        />
      </svg>
    </div>
    <div class="$$timeline-end $$timeline-box">iPod</div>
    <hr />
  </li>
  <li>
    <hr />
    <div class="$$timeline-start">2007</div>
    <div class="$$timeline-middle">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 20 20"
        fill="currentColor"
        class="h-5 w-5"
      >
        <path
          fill-rule="evenodd"
          d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z"
          clip-rule="evenodd"
        />
      </svg>
    </div>
    <div class="$$timeline-end $$timeline-box">iPhone</div>
    <hr />
  </li>
  <li>
    <hr />

```

--------------------------------

### Customize DaisyUI Built-in Theme Properties

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/themes/+page.md

This example demonstrates how to override specific CSS variables of an existing DaisyUI built-in theme, such as 'light', by redefining them within the `@plugin "daisyui/theme"` block using the same theme name. Any properties not explicitly redefined will be inherited from the original theme's default values.

```css
@import "tailwindcss";
@plugin "daisyui";
@plugin "daisyui/theme" {
  name: "light";
  default: true;
  --color-primary: blue;
  --color-secondary: teal;
}
```

--------------------------------

### Integrate Tailwind Dark Mode with DaisyUI Themes

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/themes/+page.md

This example showcases how to configure DaisyUI to work seamlessly with Tailwind CSS's `dark:` selector, enabling theme-specific dark mode styling. It demonstrates setting 'night' as a prefers-dark theme and defining a custom variant that applies Tailwind's `dark:` styles when the 'night' theme is active, allowing for responsive styling based on the active DaisyUI theme.

```css
@import "tailwindcss";
@plugin "daisyui" {
  themes: winter --default, night --prefersdark;
}

@custom-variant dark (&:where([data-theme=night], [data-theme=night] *));
```

```html
<div class="p-10 dark:p-20">
  I will have 10 padding on winter theme and 20 padding on night theme
</div>
```

--------------------------------

### Create DaisyUI Rating with Hidden Clear Option

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/rating/+page.md

This example shows a DaisyUI rating component that includes a hidden radio input (`$$rating-hidden`) at the beginning. This hidden input allows users to deselect their current rating, effectively clearing the selection. The component uses `$$mask` and `$$mask-star-2` for star rendering.

```HTML
<div class="$$rating $$rating-lg">
  <input type="radio" name="rating-10" class="$$rating-hidden" aria-label="clear" />
  <input type="radio" name="rating-10" class="$$mask $$mask-star-2" aria-label="1 star" />
  <input type="radio" name="rating-10" class="$$mask $$mask-star-2" aria-label="2 star" checked="checked" />
  <input type="radio" name="rating-10" class="$$mask $$mask-star-2" aria-label="3 star" />
  <input type="radio" name="rating-10" class="$$mask $$mask-star-2" aria-label="4 star" />
  <input type="radio" name="rating-10" class="$$mask $$mask-star-2" aria-label="5 star" />
</div>
```

--------------------------------

### Steps with Custom Colors in HTML

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/steps/+page.md

Shows how to apply different color themes to individual steps using DaisyUI's color classes like `step-info` and `step-error`, allowing for visual differentiation of process stages.

```html
<ul class="$$steps">
  <li class="$$step $$step-info">Fly to moon</li>
  <li class="$$step $$step-info">Shrink the moon</li>
  <li class="$$step $$step-info">Grab the moon</li>
  <li class="$$step $$step-error" data-content="?">Sit on toilet</li>
</ul>
```

--------------------------------

### Create a Vertical Timeline with Text and Icons using DaisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/timeline/+page.md

This HTML snippet constructs a vertical timeline layout. Each timeline item includes a start point (year), a middle section with an SVG icon, and an end point (event description). The structure leverages DaisyUI's `timeline`, `timeline-vertical`, `timeline-start`, `timeline-middle`, and `timeline-end` classes to achieve the visual presentation. It's ideal for displaying a series of events or a chronological history.

```html
<ul class="$$timeline $$timeline-vertical">
  <li>
    <div class="$$timeline-start">1984</div>
    <div class="$$timeline-middle">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 20 20"
        fill="currentColor"
        class="h-5 w-5"
      >
        <path
          fill-rule="evenodd"
          d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z"
          clip-rule="evenodd"
        />
      </svg>
    </div>
    <div class="$$timeline-end $$timeline-box">First Macintosh computer</div>
    <hr />
  </li>
  <li>
    <hr />
    <div class="$$timeline-start">1998</div>
    <div class="$$timeline-middle">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 20 20"
        fill="currentColor"
        class="h-5 w-5"
      >
        <path
          fill-rule="evenodd"
          d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z"
          clip-rule="evenodd"
        />
      </svg>
    </div>
    <div class="$$timeline-end $$timeline-box">iMac</div>
    <hr />
  </li>
  <li>
    <hr />
    <div class="$$timeline-start">2001</div>
    <div class="$$timeline-middle">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 20 20"
        fill="currentColor"
        class="h-5 w-5"
      >
        <path
          fill-rule="evenodd"
          d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z"
          clip-rule="evenodd"
        />
      </svg>
    </div>
    <div class="$$timeline-end $$timeline-box">iPod</div>
    <hr />
  </li>
  <li>
    <hr />
    <div class="$$timeline-start">2007</div>
    <div class="$$timeline-middle">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 20 20"
        fill="currentColor"
        class="h-5 w-5"
      >
        <path
          fill-rule="evenodd"
          d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z"
          clip-rule="evenodd"
        />
      </svg>
    </div>
    <div class="$$timeline-end $$timeline-box">iPhone</div>
    <hr />
  </li>
  <li>
    <hr />
    <div class="$$timeline-start">2015</div>
    <div class="$$timeline-middle">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 20 20"
        fill="currentColor"
        class="h-5 w-5"
      >
        <path
          fill-rule="evenodd"
          d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z"
          clip-rule="evenodd"
        />
      </svg>
    </div>
    <div class="$$timeline-end $$timeline-box">Apple Watch</div>
  </li>
</ul>
```

--------------------------------

### DaisyUI Responsive Footer with Logo and Social Links

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/footer/+page.md

This HTML snippet provides a complete footer component using DaisyUI classes. It includes an 'aside' section for a company logo (SVG) and text, and a 'nav' section for social media links, each represented by an SVG icon. The footer adapts its layout for small screens using 'sm:footer-horizontal'. The second code example shows a slightly different class prefixing (`$$`) and uses `<a>` tags instead of `<button>` for social links.

```html
<footer class="p-10 footer sm:footer-horizontal bg-neutral text-neutral-content rounded">
  <aside>
    <svg width="50" height="50" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg" fill-rule="evenodd" clip-rule="evenodd" class="fill-current"><path d="M22.672 15.226l-2.432.811.841 2.515c.33 1.019-.209 2.127-1.23 2.456-1.15.325-2.148-.321-2.463-1.226l-.84-2.518-5.013 1.677.84 2.517c.391 1.203-.434 2.542-1.831 2.542-.88 0-1.601-.564-1.86-1.314l-.842-2.516-2.431.809c-1.135.328-2.145-.317-2.463-1.229-.329-1.018.211-2.127 1.231-2.456l2.432-.809-1.621-4.823-2.432.808c-1.355.384-2.558-.59-2.558-1.839 0-.817.509-1.582 1.327-1.846l2.43
```

--------------------------------

### Implement a Countdown Timer Component with DaisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/countdown/+page.md

This snippet demonstrates how to create a responsive countdown timer component using DaisyUI classes. It utilizes CSS custom properties (`--$$value`) to dynamically update the countdown display for days, hours, minutes, and seconds. The component is designed to be accessible with `aria-live` and `aria-label` attributes, and includes examples for both standard HTML and JSX (React) environments.

```html
<div class="flex gap-5">
  <div>
    <span class="$$countdown font-mono text-4xl">
      <span style="--$$value:15;" aria-live="polite" aria-label="15">15</span>
    </span>
    days
  </div>
  <div>
    <span class="$$countdown font-mono text-4xl">
      <span style="--$$value:10;" aria-live="polite" aria-label="10">10</span>
    </span>
    hours
  </div>
  <div>
    <span class="$$countdown font-mono text-4xl">
      <span style="--$$value:24;" aria-live="polite" aria-label="24">24</span>
    </span>
    min
  </div>
  <div>
    <span class="$$countdown font-mono text-4xl">
      <span style="--$$value:59;" aria-live="polite" aria-label="59">59</span>
    </span>
    sec
  </div>
</div>
```

```jsx
{/* For TSX uncomment the commented types below */}
<div class="flex gap-5">
  <div>
    <span class="$$countdown font-mono text-4xl">
        <span style={{"--$$value":15} /* as React.CSSProperties */ } aria-live="polite" aria-label={counter}>15</span>
    </span>
    days
  </div>
  <div>
    <span class="$$countdown font-mono text-4xl">
        <span style={{"--$$value":10} /* as React.CSSProperties */ } aria-live="polite" aria-label={counter}>10</span>
    </span>
    hours
  </div>
  <div>
    <span class="$$countdown font-mono text-4xl">
      <span style={{"--$$value":24} /* as React.CSSProperties */ } aria-live="polite" aria-label={counter}>24</span>
    </span>
    min
  </div>
  <div>
    <span class="$$countdown font-mono text-4xl">
      <span style={{"--$$value":59} /* as React.CSSProperties */ } aria-live="polite" aria-label={counter}>59</span>
    </span>
    sec
  </div>
</div>
```

--------------------------------

### Basic Table Component Usage in HTML

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/table/+page.md

Demonstrates the basic structure of a table using the DaisyUI `table` class within an `overflow-x-auto` container for responsiveness. It includes a header and three data rows.

```HTML
<div class="overflow-x-auto">
  <table class="$$table">
    <!-- head -->
    <thead>
      <tr>
        <th></th>
        <th>Name</th>
        <th>Job</th>
        <th>Favorite Color</th>
      </tr>
    </thead>
    <tbody>
      <!-- row 1 -->
      <tr>
        <th>1</th>
        <td>Cy Ganderton</td>
        <td>Quality Control Specialist</td>
        <td>Blue</td>
      </tr>
      <!-- row 2 -->
      <tr>
        <th>2</th>
        <td>Hart Hagerty</td>
        <td>Desktop Support Technician</td>
        <td>Purple</td>
      </tr>
      <!-- row 3 -->
      <tr>
        <th>3</th>
        <td>Brice Swyre</td>
        <td>Tax Accountant</td>
        <td>Red</td>
      </tr>
    </tbody>
  </table>
</div>
```

--------------------------------

### Button styled with a single daisyUI component class

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/use/+page.md

This HTML snippet shows the simplified approach to styling a button using a single daisyUI component class, 'btn'. It illustrates how daisyUI abstracts away numerous utility classes into a concise, semantic class, making development faster and more readable.

```html
<button class="btn">Button</button>
```

--------------------------------

### Display Clock Countdown with Hours, Minutes, Seconds

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/countdown/+page.md

Shows a multi-segment clock countdown display, breaking down time into hours, minutes, and seconds. Each time unit is encapsulated in a separate `<span>` element, allowing independent styling and updates via its respective `--value` CSS variable. This setup requires JavaScript to manage and update each segment's value.

```html
<span class="$$countdown font-mono text-2xl">
  <span style="--$$value:10;" aria-live="polite" aria-label="10">10</span>
  h
  <span style="--$$value:24;" aria-live="polite" aria-label="24">24</span>
  m
  <span style="--$$value:59;" aria-live="polite" aria-label="59">59</span>
  s
</span>
```

```jsx
{/* For TSX uncomment the commented types below */}
<span class="$$countdown font-mono text-2xl">
  <span style={{"--$$value":10} /* as React.CSSProperties */ } aria-live="polite" aria-label={counter}>10</span>h
  <span style={{"--$$value":24} /* as React.CSSProperties */ } aria-live="polite" aria-label={counter}>24</span>m
  <span style={{"--$$value":59} /* as React.CSSProperties */ } aria-live="polite" aria-label={counter}>59</span>s
</span>
```

--------------------------------

### Customize Astro Documentation Header Component

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/daisyui-astro-tailwind-documentation-template/+page.md

This Astro component defines the sticky header for the documentation pages. It includes navigation elements, a search bar placeholder, social links, and a theme toggle, allowing for customization of the site's top navigation and branding.

```astro
<header class="sticky top-0 z-30">
  <nav class="navbar bg-base-100/90 shadow-sm backdrop-blur-lg justify-center items-center py-2 md:px-10 px-2 border-b border-base-content/10">
    <div class="navbar-start">
      <label for="my-drawer-2" class="btn btn-square btn-ghost lg:hidden">
        <svg
          xmlns="http://www.w3.org/2000/svg"
          fill="none"
          viewBox="0 0 24 24"
          class="inline-block w-5 h-5 stroke-current"
        >
          <path
            stroke-linecap="round"
            stroke-linejoin="round"
            stroke-width="2"
            d="M4 6h16M4 12h16M4 18h16"
          ></path>
        </svg>
      </label>
    </div>

    <div class="navbar-end">
      <a
        class="btn btn-sm btn-ghost"
        href="https://www.x.com"
        aria-label="twitter"
      >
        <svg viewBox="0 0 24 24" aria-hidden="true" class="h-4 w-4">
          <path
            d="M13.3174 10.7749L19.1457 4H17.7646L12.7039 9.88256L8.66193 4H4L10.1122 12.8955L4 20H5.38119L10.7254 13.7878L14.994 20H19.656L13.3171 10.7749H13.3174ZM11.4257 12.9738L10.8064 12.0881L5.87886 5.03974H8.00029L11.9769 10.728L12.5962 11.6137L17.7652 19.0075H15.6438L11.4257 12.9742V12.9738Z"
            fill="currentColor"
          ></path>
        </svg>
      </a>
      <ThemeToggle />
    </div>
  </nav>
</header>
```

--------------------------------

### Create DaisyUI Tabs with Various Sizes

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/tab/+page.md

Demonstrates how to implement DaisyUI tabs using the 'tabs-lift' style with different predefined sizes (xs, sm, md, lg, xl). Each size is applied to a 'div' with 'role="tablist"' containing 'a' elements that act as individual tabs. This allows for flexible styling based on component size requirements.

```html
<div role="tablist" class="$$tabs $$tabs-lift $$tabs-xs">
  <a role="tab" class="$$tab">Xsmall</a>
  <a role="tab" class="$$tab $$tab-active">Xsmall</a>
  <a role="tab" class="$$tab">Xsmall</a>
</div>

<div role="tablist" class="$$tabs $$tabs-lift $$tabs-sm">
  <a role="tab" class="$$tab">Small</a>
  <a role="tab" class="$$tab $$tab-active">Small</a>
  <a role="tab" class="$$tab">Small</a>
</div>

<div role="tablist" class="$$tabs $$tabs-lift">
  <a role="tab" class="$$tab">Medium</a>
  <a role="tab" class="$$tab $$tab-active">Medium</a>
  <a role="tab" class="$$tab">Medium</a>
</div>

<div role="tablist" class="$$tabs $$tabs-lift $$tabs-lg">
  <a role="tab" class="$$tab">Large</a>
  <a role="tab" class="$$tab $$tab-active">Large</a>
  <a role="tab" class="$$tab">Large</a>
</div>

<div role="tablist" class="$$tabs $$tabs-lift $$tabs-xl">
  <a role="tab" class="$$tab">Xlarge</a>
  <a role="tab" class="$$tab $$tab-active">Xlarge</a>
  <a role="tab" class="$$tab">Xlarge</a>
</div>
```

--------------------------------

### Create a Basic Timeline Component with DaisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/timeline/+page.md

This HTML snippet outlines the structure for a timeline component using DaisyUI's `timeline` classes. It includes elements for event descriptions (`timeline-start`, `timeline-end`), visual markers (`timeline-middle` with SVG icons), and connecting lines (`hr` elements). The `$$` prefix indicates DaisyUI's configurable class prefix, allowing for easy integration and styling.

```html
<ul class="$$timeline">
  <li>
    <div class="$$timeline-start $$timeline-box">First Macintosh computer</div>
    <div class="$$timeline-middle">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 20 20"
        fill="currentColor"
        class="text-primary h-5 w-5"
      >
        <path
          fill-rule="evenodd"
          d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z"
          clip-rule="evenodd"
        />
      </svg>
    </div>
    <hr class="bg-primary" />
  </li>
  <li>
    <hr class="bg-primary" />
    <div class="$$timeline-middle">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 20 20"
        fill="currentColor"
        class="text-primary h-5 w-5"
      >
        <path
          fill-rule="evenodd"
          d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z"
          clip-rule="evenodd"
        />
      </svg>
    </div>
    <div class="$$timeline-end $$timeline-box">iMac</div>
    <hr class="bg-primary" />
  </li>
  <li>
    <hr class="bg-primary" />
    <div class="$$timeline-start $$timeline-box">iPod</div>
    <div class="$$timeline-middle">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 20 20"
        fill="currentColor"
        class="text-primary h-5 w-5"
      >
        <path
          fill-rule="evenodd"
          d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z"
          clip-rule="evenodd"
        />
      </svg>
    </div>
    <hr />
  </li>
  <li>
    <hr />
    <div class="$$timeline-middle">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 20 20"
        fill="currentColor"
        class="h-5 w-5"
      >
        <path
          fill-rule="evenodd"
          d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z"
          clip-rule="evenodd"
        />
      </svg>
    </div>
    <div class="$$timeline-end $$timeline-box">iPhone</div>
    <hr />
  </li>
  <li>
    <hr />
    <div class="$$timeline-start $$timeline-box">Apple Watch</div>
    <div class="$$timeline-middle">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 20 20"
        fill="currentColor"
        class="h-5 w-5"
      >
        <path
          fill-rule="evenodd"
          d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z"
          clip-rule="evenodd"
        />
      </svg>
    </div>
  </li>
</ul>
```

--------------------------------

### Implement a Vertical Timeline with Right-Side Content in HTML

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/timeline/+page.md

This HTML snippet demonstrates the structure for a vertical timeline component using DaisyUI. It showcases how to arrange timeline markers (with SVG icons) and content boxes (`timeline-box`) so that all event details appear on the right side of the timeline. The example includes multiple timeline items, each separated by a horizontal rule (`<hr/>`) for visual continuity.

```html
<ul class="timeline timeline-vertical">
  <li>
    <div class="timeline-middle">
      <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor" class="w-5 h-5"><path fill-rule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z" clip-rule="evenodd" /></svg>
    </div>
    <div class="timeline-end timeline-box">First Macintosh computer</div>
    <hr/>
  </li>
  <li>
    <hr/>
    <div class="timeline-middle">
      <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor" class="w-5 h-5"><path fill-rule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z" clip-rule="evenodd" /></svg>
    </div>
    <div class="timeline-end timeline-box">iMac</div>
    <hr/>
  </li>
  <li>
    <hr/>
    <div class="timeline-middle">
      <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor" class="w-5 h-5"><path fill-rule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z" clip-rule="evenodd" /></svg>
    </div>
    <div class="timeline-end timeline-box">iPod</div>
    <hr/>
  </li>
  <li>
    <hr/>
    <div class="timeline-middle">
      <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor" class="w-5 h-5"><path fill-rule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z" clip-rule="evenodd" /></svg>
    </div>
    <div class="timeline-end timeline-box">iPhone</div>
    <hr/>
  </li>
  <li>
    <hr/>
    <div class="timeline-middle">
      <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor" class="w-5 h-5"><path fill-rule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z" clip-rule="evenodd" /></svg>
    </div>
    <div class="timeline-end timeline-box">Apple Watch</div>
  </li>
</ul>
```

```html
<ul class="$$timeline $$timeline-vertical">
  <li>
    <div class="$$timeline-middle">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 20 20"
        fill="currentColor"
        class="h-5 w-5"
      >
        <path
          fill-rule="evenodd"
          d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z"
          clip-rule="evenodd"
        />
      </svg>
    </div>
    <div class="$$timeline-end $$timeline-box">First Macintosh computer</div>
    <hr />
  </li>
  <li>
    <hr />
    <div class="$$timeline-middle">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 20 20"
        fill="currentColor"
        class="h-5 w-5"
      >
        <path
          fill-rule="evenodd"
          d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z"
          clip-rule="evenodd"
        />
      </svg>
    </div>
    <div class="$$timeline-end $$timeline-box">iMac</div>
    <hr />
  </li>
  <li>
    <hr />
    <div class="$$timeline-middle">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 20 20"
        fill="currentColor"
        class="h-5 w-5"
      >
        <path
          fill-rule="evenodd"
          d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z"
          clip-rule="evenodd"
        />
      </svg>
    </div>
    <div class="$$timeline-end $$timeline-box">iPod</div>
    <hr />
  </li>
  <li>
    <hr />
    <div class="$$timeline-middle">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 20 20"
        fill="currentColor"
        class="h-5 w-5"
      >
        <path
          fill-rule="evenodd"
          d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z"
          clip-rule="evenodd"
        />
      </svg>
    </div>
    <div class="$$timeline-end $$timeline-box">iPhone</div>
    <hr />
  </li>
  <li>
    <hr />
    <div class="$$timeline-middle">
      <svg
        xmlns="http://www.w3.org/2000/svg"
        viewBox="0 0 20 20"
        fill="currentColor"
        class="h-5 w-5"
      >
        <path
          fill-rule="evenodd"
          d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z"
          clip-rule="evenodd"
        />
      </svg>
    </div>
    <div class="$$timeline-end $$timeline-box">Apple Watch</div>
  </li>
</ul>
```

--------------------------------

### Create a Horizontal Carousel with Half-Width Items using DaisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/carousel/+page.md

This example illustrates a horizontal carousel where each item takes up half the width of the carousel container. The `w-1/2` class applied to `carousel-item` elements enables multiple items to be visible simultaneously, creating a multi-item carousel effect suitable for showcasing several items at once.

```html
<div class="$$carousel rounded-box w-96">
  <div class="$$carousel-item w-1/2">
    <img
      src="https://img.daisyui.com/images/stock/photo-1559703248-dcaaec9fab78.webp"
      class="w-full" />
  </div>
  <div class="$$carousel-item w-1/2">
    <img
      src="https://img.daisyui.com/images/stock/photo-1565098772267-60af42b81ef2.webp"
      class="w-full" />
  </div>
  <div class="$$carousel-item w-1/2">
    <img
      src="https://img.daisyui.com/images/stock/photo-1572635148818-ef6fd45eb394.webp"
      class="w-full" />
  </div>
  <div class="$$carousel-item w-1/2">
    <img
      src="https://img.daisyui.com/images/stock/photo-1494253109108-2e30c049369b.webp"
      class="w-full" />
  </div>
  <div class="$$carousel-item w-1/2">
    <img
      src="https://img.daisyui.com/images/stock/photo-1550258987-190a2d41a8ba.webp"
      class="w-full" />
  </div>
  <div class="$$carousel-item w-1/2">
    <img
      src="https://img.daisyui.com/images/stock/photo-1559181567-c3190ca9959b.webp"
      class="w-full" />
  </div>
  <div class="$$carousel-item w-1/2">
    <img
      src="https://img.daisyui.com/images/stock/photo-1601004890684-d8cbf643f5f2.webp"
      class="w-full" />
  </div>
</div>
```

--------------------------------

### DaisyUI Generic Dock Component Template

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/dock/+page.md

A generic HTML template for implementing a DaisyUI dock component. It uses placeholders (`$$dock`, `$$dock-xs`, `$$dock-active`) to indicate where DaisyUI classes should be applied, providing a flexible structure for various dock configurations and sizes.

```HTML
<div class="$$dock $$dock-xs">
  <button>
    <svg class="size-[1.2em]" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24"><g fill="currentColor" stroke-linejoin="miter" stroke-linecap="butt"><polyline points="1 11 12 2 23 11" fill="none" stroke="currentColor" stroke-miterlimit="10" stroke-width="2"></polyline><path d="m5,13v7c0,1.105.895,2,2,2h10c1.105,0,2-.895,2-2v-7" fill="none" stroke="currentColor" stroke-linecap="square" stroke-miterlimit="10" stroke-width="2"></path><line x1="12" y1="22" x2="12" y2="18" fill="none" stroke="currentColor" stroke-linecap="square" stroke-miterlimit="10" stroke-width="2"></line></g></svg>
  </button>
  
  <button class="$$dock-active">
    <svg class="size-[1.2em]" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24"><g fill="currentColor" stroke-linejoin="miter" stroke-linecap="butt"><polyline points="3 14 9 14 9 17 15 17 15 14 21 14" fill="none" stroke="currentColor" stroke-miterlimit="10" stroke-width="2"></polyline><rect x="3" y="3" width="18" height="18" rx="2" ry="2" fill="none" stroke="currentColor" stroke-linecap="square" stroke-miterlimit="10" stroke-width="2"></rect></g></svg>
  </button>
  
  <button>
    <svg class="size-[1.2em]" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24"><g fill="currentColor" stroke-linejoin="miter" stroke-linecap="butt"><circle cx="12" cy="12" r="3" fill="none" stroke="currentColor" stroke-linecap="square" stroke-miterlimit="10" stroke-width="2"></circle><path d="m22,13.25v-2.5l-2.318-.966c-.167-.581-.395-1.135-.682-1.654l.954-2.318-1.768-1.768-2.318.954c-.518-.287-1.073-.515-1.654-.682l-.966-2.318h-2.5l-.966,2.318c-.581.167-1.135.395-1.654.682l-2.318-.954-1.768,1.768.954,2.318c-.287.518-.515,1.073-.682,1.654l-2.318.966v2.5l2.318.966c.167.581.395,1.135.682,1.654l-.954,2.318,1.768,1.768,2.318-.954c.518.287,1.073.515,1.654.682l.966,2.318h2.5l.966-2.318c.581-.167,1.135-.395,1.654-.682l2.318.954,1.768-1.768-.954-2.318c.287-.518.515-1.073.682-1.654l2.318-.966Z" fill="none" stroke="currentColor" stroke-linecap="square" stroke-miterlimit="10" stroke-width="2"></path></g></svg>
  </button>
</div>
```

--------------------------------

### Table with Border and Background in HTML

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/table/+page.md

Shows how to apply a border and background to a table using DaisyUI utility classes like `rounded-box`, `border`, `border-base-content/5`, and `bg-base-100` on the `overflow-x-auto` container, in addition to the basic table structure.

```HTML
<div class="overflow-x-auto rounded-box border border-base-content/5 bg-base-100">
  <table class="$$table">
    <!-- head -->
    <thead>
      <tr>
        <th></th>
        <th>Name</th>
        <th>Job</th>
        <th>Favorite Color</th>
      </tr>
    </thead>
    <tbody>
      <!-- row 1 -->
      <tr>
        <th>1</th>
        <td>Cy Ganderton</td>
        <td>Quality Control Specialist</td>
        <td>Blue</td>
      </tr>
      <!-- row 2 -->
      <tr>
        <th>2</th>
        <td>Hart Hagerty</td>
        <td>Desktop Support Technician</td>
        <td>Purple</td>
      </tr>
      <!-- row 3 -->
      <tr>
        <th>3</th>
        <td>Brice Swyre</td>
        <td>Tax Accountant</td>
        <td>Red</td>
      </tr>
    </tbody>
  </table>
</div>
```

--------------------------------

### Displaying Data in an HTML Table with DaisyUI Classes

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/table/+page.md

This snippet demonstrates a basic HTML table structure, enhanced with DaisyUI utility classes for styling and responsiveness. It includes a header, body with multiple rows of sample data, and a footer. The `overflow-x-auto` class ensures horizontal scrolling for smaller screens, and `$$table` classes are placeholders for DaisyUI table styling.

```html
<div class="overflow-x-auto">
  <table class="$$table $$table-xs $$table-pin-rows $$table-pin-cols">
    <thead>
      <tr>
        <th></th>
        <td>Name</td>
        <td>Job</td>
        <td>company</td>
        <td>location</td>
        <td>Last Login</td>
        <td>Favorite Color</td>
        <th></th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <th>1</th>
        <td>Cy Ganderton</td>
        <td>Quality Control Specialist</td>
        <td>Littel, Schaden and Vandervort</td>
        <td>Canada</td>
        <td>12/16/2020</td>
        <td>Blue</td>
        <th>1</th>
      </tr>
      <tr>
        <th>2</th>
        <td>Hart Hagerty</td>
        <td>Desktop Support Technician</td>
        <td>Zemlak, Daniel and Leannon</td>
        <td>United States</td>
        <td>12/5/2020</td>
        <td>Purple</td>
        <th>2</th>
      </tr>
      <tr>
        <th>3</th>
        <td>Brice Swyre</td>
        <td>Tax Accountant</td>
        <td>Carroll Group</td>
        <td>China</td>
        <td>8/15/2020</td>
        <td>Red</td>
        <th>3</th>
      </tr>
      <tr>
        <th>4</th>
        <td>Marjy Ferencz</td>
        <td>Office Assistant I</td>
        <td>Rowe-Schoen</td>
        <td>Russia</td>
        <td>3/25/2021</td>
        <td>Crimson</td>
        <th>4</th>
      </tr>
      <tr>
        <th>5</th>
        <td>Yancy Tear</td>
        <td>Community Outreach Specialist</td>
        <td>Wyman-Ledner</td>
        <td>Brazil</td>
        <td>5/22/2020</td>
        <td>Indigo</td>
        <th>5</th>
      </tr>
      <tr>
        <th>6</th>
        <td>Irma Vasilik</td>
        <td>Editor</td>
        <td>Wiza, Bins and Emard</td>
        <td>Venezuela</td>
        <td>12/8/2020</td>
        <td>Purple</td>
        <th>6</th>
      </tr>
      <tr>
        <th>7</th>
        <td>Meghann Durtnal</td>
        <td>Staff Accountant IV</td>
        <td>Schuster-Schimmel</td>
        <td>Philippines</td>
        <td>2/17/2021</td>
        <td>Yellow</td>
        <th>7</th>
      </tr>
      <tr>
        <th>8</th>
        <td>Sammy Seston</td>
        <td>Accountant I</td>
        <td>O'Hara, Welch and Keebler</td>
        <td>Indonesia</td>
        <td>5/23/2020</td>
        <td>Crimson</td>
        <th>8</th>
      </tr>
      <tr>
        <th>9</th>
        <td>Lesya Tinham</td>
        <td>Safety Technician IV</td>
        <td>Turner-Kuhlman</td>
        <td>Philippines</td>
        <td>2/21/2021</td>
        <td>Maroon</td>
        <th>9</th>
      </tr>
      <tr>
        <th>10</th>
        <td>Zaneta Tewkesbury</td>
        <td>VP Marketing</td>
        <td>Sauer LLC</td>
        <td>Chad</td>
        <td>6/23/2020</td>
        <td>Green</td>
        <th>10</th>
      </tr>
      <tr>
        <th>11</th>
        <td>Andy Tipple</td>
        <td>Librarian</td>
        <td>Hilpert Group</td>
        <td>Poland</td>
        <td>7/9/2020</td>
        <td>Indigo</td>
        <th>11</th>
      </tr>
      <tr>
        <th>12</th>
        <td>Sophi Biles</td>
        <td>Recruiting Manager</td>
        <td>Gutmann Inc</td>
        <td>Indonesia</td>
        <td>2/12/2021</td>
        <td>Maroon</td>
        <th>12</th>
      </tr>
      <tr>
        <th>13</th>
        <td>Florida Garces</td>
        <td>Web Developer IV</td>
        <td>Gaylord, Pacocha and Baumbach</td>
        <td>Poland</td>
        <td>5/31/2020</td>
        <td>Purple</td>
        <th>13</th>
      </tr>
      <tr>
        <th>14</th>
        <td>Maribeth Popping</td>
        <td>Analyst Programmer</td>
        <td>Deckow-Pouros</td>
        <td>Portugal</td>
        <td>4/27/2021</td>
        <td>Aquamarine</td>
        <th>14</th>
      </tr>
      <tr>
        <th>15</th>
        <td>Moritz Dryburgh</td>
        <td>Dental Hygienist</td>
        <td>Schiller, Cole and Hackett</td>
        <td>Sri Lanka</td>
        <td>8/8/2020</td>
        <td>Crimson</td>
        <th>15</th>
      </tr>
      <tr>
        <th>16</th>
        <td>Reid Semiras</td>
        <td>Teacher</td>
        <td>Sporer, Sipes and Rogahn</td>
        <td>Poland</td>
        <td>7/30/2020</td>
        <td>Green</td>
        <th>16</th>
      </tr>
      <tr>
        <th>17</th>
        <td>Alec Lethby</td>
        <td>Teacher</td>
        <td>Reichel, Glover and Hamill</td>
        <td>China</td>
        <td>2/28/2021</td>
        <td>Khaki</td>
        <th>17</th>
      </tr>
    </tbody>
    <tfoot>
      <tr>
        <th></th>
        <td>Name</td>
        <td>Job</td>
        <td>company</td>
        <td>location</td>
        <td>Last Login</td>
        <td>Favorite Color</td>
        <th></th>
      </tr>
    </tfoot>
  </table>
</div>
```

--------------------------------

### Circular Skeleton Placeholder with Content Structure in HTML

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/skeleton/+page.md

Illustrates a more complex skeleton loading pattern, featuring a circular placeholder (e.g., for an avatar) alongside text line placeholders. This simulates a user profile or card loading state, providing a visual cue while data is fetched.

```html
<div class="flex w-52 flex-col gap-4">
  <div class="flex items-center gap-4">
    <div class="skeleton h-16 w-16 shrink-0 rounded-full"></div>
    <div class="flex flex-col gap-4">
      <div class="skeleton h-4 w-20"></div>
      <div class="skeleton h-4 w-28"></div>
    </div>
  </div>
  <div class="skeleton h-32 w-full"></div>
</div>
```

--------------------------------

### Join Radio Inputs with Button Styling

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/join/+page.md

Shows how to integrate radio input elements within a 'join' container and style them to look like buttons using the 'btn' class, creating a group of selectable options.

```HTML
<div class="join">
  <input class="join-item btn" type="radio" name="options" aria-label="Radio 1" />
  <input class="join-item btn" type="radio" name="options" aria-label="Radio 2" />
  <input class="join-item btn" type="radio" name="options" aria-label="Radio 3" />
</div>
```

--------------------------------

### Execute CSS build script

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/htmx/+page.md

Runs the 'build:css' script defined in package.json. This command compiles your PostCSS file (app.css) into a production-ready CSS file (public/output.css) using Tailwind CSS and daisyUI.

```sh
npm run build:css
```

--------------------------------

### Responsive Join Layout

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/join/+page.md

Shows how to implement a responsive 'join' container that displays items vertically on small screens and horizontally on large screens using Tailwind CSS utility classes like 'lg:join-horizontal'.

```HTML
<div class="join join-vertical lg:join-horizontal">
  <button class="btn join-item">Button</button>
  <button class="btn join-item">Button</button>
  <button class="btn join-item">Button</button>
</div>
```

--------------------------------

### Importing Svelte Components

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/faq/+page.md

Demonstrates how to import a Svelte component from a relative path within a Svelte script block. This is a common pattern for including reusable UI elements or utility functions in Svelte applications.

```Svelte
<script>\n  import Translate from "$components/Translate.svelte"\n</script>
```

--------------------------------

### Text Input with Label, Icons, and Badges using DaisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/input/+page.md

Shows how to create a more complex input group by wrapping an input with a `label` and including icons (SVG), keyboard shortcuts (`kbd`), and badges (`span`) within the `input` class container. This allows for rich, interactive input fields.

```HTML
<label class="$$input">
  <svg class="h-[1em] opacity-50" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24">
    <g
      stroke-linejoin="round"
      stroke-linecap="round"
      stroke-width="2.5"
      fill="none"
      stroke="currentColor"
    >
      <circle cx="11" cy="11" r="8"></circle>
      <path d="m21 21-4.3-4.3"></path>
    </g>
  </svg>
  <input type="search" class="grow" placeholder="Search" />
  <kbd class="$$kbd $$kbd-sm">⌘</kbd>
  <kbd class="$$kbd $$kbd-sm">K</kbd>
</label>
<label class="$$input">
  <svg class="h-[1em] opacity-50" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24">
    <g
      stroke-linejoin="round"
      stroke-linecap="round"
      stroke-width="2.5"
      fill="none"
      stroke="currentColor"
    >
      <path d="M15 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V7Z"></path>
      <path d="M14 2v4a2 2 0 0 0 2 2h4"></path>
    </g>
  </svg>
  <input type="text" class="grow" placeholder="index.php" />
</label>
<label class="$$input">
  Path
  <input type="text" class="grow" placeholder="src/app/" />
  <span class="$$badge $$badge-neutral $$badge-xs">Optional</span>
</label>
```

--------------------------------

### DaisyUI Date Picker Integration Syntax

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/static/llms.txt

Demonstrates the HTML syntax for integrating different date picker libraries with DaisyUI. It shows how to apply DaisyUI classes to elements used by Cally, Pikaday, and React Day Picker.

```html
<calendar-date class="cally">{CONTENT}</calendar-date>
<input type="text" class="input pika-single">
<DayPicker className="react-day-picker">
```

--------------------------------

### Change Font Family and Typography in Nexus

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/nexus-dashboard-template/+page.md

This CSS example illustrates how to modify the font family and text sizes within the Nexus dashboard template. It uses Google Fonts via `@import` and defines custom CSS variables for font family and specific text sizes. This configuration is typically found in `typography.css`.

```css
/* update: font family url */
@import url("https://...");

@theme {
  /* update: font family variable */
  --font-body: "DM Sans", sans-serif;

  /* update: font size */
  --text-sm: 14px;
  --text-base: 16px;

  /* add: more options related to font  */
}
```

--------------------------------

### Basic Join Container

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/join/+page.md

Demonstrates the fundamental usage of the 'join' class to group multiple button elements horizontally, applying border radius to the first and last items automatically.

```HTML
<div class="join">
  <button class="btn join-item">Button</button>
  <button class="btn join-item">Button</button>
  <button class="btn join-item">Button</button>
</div>
```

--------------------------------

### Configure Bun to use Tailwind CSS plugin

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/bun/+page.md

This `bunfig.toml` configuration enables the `bun-plugin-tailwind` for static file serving. It ensures that Tailwind CSS processing is applied to served files, allowing for dynamic styling.

```toml
[serve.static]
plugins = ["bun-plugin-tailwind"]
```

--------------------------------

### DaisyUI Mockup Browser Component

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/static/llms.txt

The Mockup Browser component displays a box that looks like a browser window, including a toolbar.

```html
<div class="mockup-browser">
  <div class="mockup-browser-toolbar">
    <input class="input" placeholder="Search or type a URL" />
  </div>
  <div class="mockup-browser-window">
    {CONTENT}
  </div>
</div>
```

--------------------------------

### Default daisyUI PostCSS Plugin Configuration

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/config/+page.md

Shows the default configuration options available within the daisyUI PostCSS plugin, including themes, root selector, component inclusion/exclusion, prefixing, and logging.

```postcss
@plugin "daisyui" {
  themes: light --default, dark --prefersdark;
  root: ":root";
  include: ;
  exclude: ;
  prefix: ;
  logs: true;
}
```

--------------------------------

### Create a basic iPhone mockup with DaisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/mockup-phone/+page.md

This HTML snippet demonstrates how to create a basic iPhone mockup using DaisyUI's `mockup-phone` component, including the camera and display parts. The display shows a simple text message.

```html
<div class="$$mockup-phone">
  <div class="$$mockup-phone-camera"></div>
  <div class="$$mockup-phone-display text-white grid place-content-center">It's Glowtime.</div>
</div>
```

--------------------------------

### DaisyUI Diff Component Syntax

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/static/llms.txt

Demonstrates the HTML structure for DaisyUI's diff component, used for displaying differences between two items. It includes a resizer element and notes on maintaining aspect ratio with specific classes.

```html
<figure class="diff">
  <div class="diff-item-1">{item1}</div>
  <div class="diff-item-2">{item2}</div>
  <div class="diff-resizer"></div>
</figure>
```

--------------------------------

### Steps with Data-Content Attribute in HTML

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/steps/+page.md

Illustrates the use of the `data-content` attribute on `li` elements to display custom characters or symbols next to each step, providing additional visual cues.

```html
<ul class="$$steps">
  <li data-content="?" class="$$step $$step-neutral">Step 1</li>
  <li data-content="!" class="$$step $$step-neutral">Step 2</li>
  <li data-content="✓" class="$$step $$step-neutral">Step 3</li>
  <li data-content="✕" class="$$step $$step-neutral">Step 4</li>
  <li data-content="★" class="$$step $$step-neutral">Step 5</li>
  <li data-content="" class="$$step $$step-neutral">Step 6</li>
  <li data-content="●" class="$$step $$step-neutral">Step 7</li>
</ul>
```

--------------------------------

### Create a basic HTML Textarea

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/textarea/+page.md

This snippet demonstrates how to create a fundamental textarea element for multi-line text input. It includes a placeholder for user guidance.

```html
<textarea class="$$textarea" placeholder="Bio"></textarea>
```

--------------------------------

### DaisyUI Stack Component

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/static/llms.txt

Documentation for the DaisyUI stack component. Visually puts elements on top of each other. Supports modifiers for alignment and allows setting dimensions with utility classes.

```html
<div class="stack {MODIFIER}">{CONTENT}</div>

Rules:
- {MODIFIER} is optional and can have one of the modifier class names.
- You can use `w-*` and `h-*` classes to set the width and height of the stack, making all items the same size.
```

--------------------------------

### Create a Responsive DaisyUI Button

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/button/+page.md

Illustrates how to make a button responsive, changing its size based on different screen breakpoints (sm, md, lg, xl) using Tailwind CSS responsive prefixes with DaisyUI classes.

```html
<button class="$$btn $$btn-xs sm:$$btn-sm md:$$btn-md lg:$$btn-lg xl:$$btn-xl">Responsive</button>
```

--------------------------------

### Implement DaisyUI List with Third Column Wrapping

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/list/+page.md

This HTML snippet demonstrates how to create a responsive list component using DaisyUI. It utilizes `list`, `list-row`, and `list-col-wrap` classes to display items where the third column's content wraps to the next line. It also includes interactive buttons with SVG icons for actions like playing or liking a song.

```html
<ul class="list bg-base-100 rounded-box shadow-md">
  
  <li class="p-4 pb-2 text-xs opacity-60 tracking-wide">Most played songs this week</li>
  
  <li class="list-row">
    <div><img class="size-10 rounded-box" src="https://img.daisyui.com/images/profile/demo/1@94.webp"/></div>
    <div>
      <div>Dio Lupa</div>
      <div class="text-xs uppercase font-semibold opacity-60">Remaining Reason</div>
    </div>
    <p class="list-col-wrap text-xs">
      "Remaining Reason" became an instant hit, praised for its haunting sound and emotional depth. A viral performance brought it widespread recognition, making it one of Dio Lupa’s most iconic tracks.
    </p>
    <button class="btn btn-square btn-ghost">
      <svg class="size-[1.2em]" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24"><g stroke-linejoin="round" stroke-linecap="round" stroke-width="2" fill="none" stroke="currentColor"><path d="M6 3L20 12 6 21 6 3z"></path></g></svg>
    </button>

```

--------------------------------

### Basic Text Input with DaisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/input/+page.md

Demonstrates a standard text input field styled with the DaisyUI `input` class, providing a clean and consistent look for user input.

```HTML
<input type="text" placeholder="Type here" class="$$input" />
```

--------------------------------

### Steps with Custom Icons in HTML

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/steps/+page.md

Demonstrates how to embed custom content or icons within the `step-icon` span element for each step, enhancing visual representation of the process.

```html
<ul class="$$steps">
  <li class="$$step $$step-neutral">
    <span class="$$step-icon">😕</span>Step 1
  </li>
  <li class="$$step $$step-neutral">
    <span class="$$step-icon">😃</span>Step 2
  </li>
  <li class="$$step">
    <span class="$$step-icon">😍</span>Step 3
  </li>
</ul>
```

--------------------------------

### Basic HTML Structure for DaisyUI Badge

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/badge/+page.md

Demonstrates the fundamental HTML structure for creating a simple badge component using the `badge` class. This is the most basic implementation of a DaisyUI badge.

```HTML
<span class="$$badge">Badge</span>
```

--------------------------------

### Make Tailwind CSS CLI Executable

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/standalone/+page.md

Applies execute permissions to the downloaded `tailwindcss` binary on Linux and macOS systems using `chmod +x`. This step is necessary before the CLI can be run.

```sh
chmod +x tailwindcss
```

--------------------------------

### Link compiled CSS in HTML

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/htmx/+page.md

Includes the generated 'output.css' file from the 'public' directory into your HTML document. This link ensures that the daisyUI styles are applied to your web page.

```html
<link href="./output.css" rel="stylesheet">
```

--------------------------------

### Basic daisyUI 5 Plugin Configuration in CSS

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/blog/(posts)/daisyui-5-alpha/+page.md

This CSS snippet shows the minimal configuration to include Tailwind CSS and enable the daisyUI plugin in your stylesheet. It assumes Tailwind CSS 4 alpha is already set up.

```css
@import "tailwindcss";
@plugin "daisyui";
```

--------------------------------

### DaisyUI Tooltip Component API Reference

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/tooltip/+page.md

Defines the available classes and their descriptions for customizing the DaisyUI Tooltip component. Includes classes for component structure, content, placement, forced state, and various color themes.

```APIDOC
Tooltip Component Classes:

Component Container:
  .tooltip: Container element for the tooltip.

Tooltip Content:
  .tooltip-content: Optional. Use a div with this class as the content of the tooltip instead of the `data-tip` text for custom HTML.

Placement Modifiers:
  .tooltip-top: Positions the tooltip on top (default).
  .tooltip-bottom: Positions the tooltip on bottom.
  .tooltip-left: Positions the tooltip on left.
  .tooltip-right: Positions the tooltip on right.

State Modifiers:
  .tooltip-open: Forces the tooltip to be open and visible.

Color Modifiers:
  .tooltip-neutral: Applies a neutral color theme to the tooltip.
  .tooltip-primary: Applies the primary theme color to the tooltip.
  .tooltip-secondary: Applies the secondary theme color to the tooltip.
  .tooltip-accent: Applies the accent theme color to the tooltip.
  .tooltip-info: Applies an informational color theme to the tooltip.
  .tooltip-success: Applies a success color theme to the tooltip.
  .tooltip-warning: Applies a warning color theme to the tooltip.
  .tooltip-error: Applies an error color theme to the tooltip.
```

--------------------------------

### Rectangular Skeleton Placeholder with Multiple Text Lines in HTML

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/skeleton/+page.md

Shows a skeleton loading state for a block of content, including a large rectangular placeholder (e.g., for an image or main content area) and multiple lines of text placeholders below it. This pattern is ideal for articles, product cards, or any content block with varying elements.

```html
<div class="flex w-52 flex-col gap-4">
  <div class="skeleton h-32 w-full"></div>
  <div class="skeleton h-4 w-28"></div>
  <div class="skeleton h-4 w-full"></div>
  <div class="skeleton h-4 w-full"></div>
</div>
```

--------------------------------

### File Input with Fieldset and Label

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/file-input/+page.md

Illustrates how to semantically group a file input using a 'fieldset' and 'legend' for a title, and how to include a 'label' for additional descriptive text or constraints.

```HTML
<fieldset class="$$fieldset">
  <legend class="$$fieldset-legend">Pick a file</legend>
  <input type="file" class="$$file-input" />
  <label class="$$label">Max size 2MB</label>
</fieldset>
```

--------------------------------

### Apply Different Sizes to DaisyUI Buttons

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/button/+page.md

Shows how to create buttons with various predefined sizes (extra small, small, medium, large, extra large) using DaisyUI's size utility classes.

```html
<button class="$$btn $$btn-xs">Xsmall</button>
<button class="$$btn $$btn-sm">Small</button>
<button class="$$btn">Medium</button>
<button class="$$btn $$btn-lg">Large</button>
<button class="$$btn $$btn-xl">Xlarge</button>
```

--------------------------------

### Configure PostCSS for Tailwind CSS and daisyUI

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/standalone/+page.md

Illustrates the `input.css` configuration for PostCSS, importing Tailwind CSS and daisyUI. It specifies source files for Tailwind's JIT compilation and includes an optional block for custom daisyUI themes.

```postcss
@import "tailwindcss" source(none);
@source "./public/*.{html,php,erb}";
@plugin "./daisyui.js";

/* Optional for custom themes – Docs: https://daisyui.com/docs/themes/#how-to-add-a-new-custom-theme */
@plugin "./daisyui-theme.js"{
  /* custom theme here */
}
```

--------------------------------

### Build an HTML Collapse Component with Details and Summary Tags

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/collapse/+page.md

This method utilizes the native HTML `<details>` and `<summary>` tags for a collapse effect. Note that `collapse-open` and `collapse-close` classes do not apply here; control is achieved by adding or removing the `open` attribute on the `<details>` tag. This approach inherently limits CSS transitions for animations.

```html
<details class="$$collapse bg-base-100 border-base-300 border">
  <summary class="$$collapse-title font-semibold">How do I create an account?</summary>
  <div class="$$collapse-content text-sm">
    Click the "Sign Up" button in the top right corner and follow the registration process.
  </div>
</details>
```

--------------------------------

### Download daisyUI JavaScript Bundles

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/standalone/+page.md

Uses `curl` to download the latest `daisyui.js` and `daisyui-theme.js` files. These JavaScript bundles are required to integrate daisyUI components and themes with Tailwind CSS.

```sh
curl -sLO https://github.com/saadeghi/daisyui/releases/latest/download/daisyui.js
curl -sLO https://github.com/saadeghi/daisyui/releases/latest/download/daisyui-theme.js
```

--------------------------------

### Implement DaisyUI Loading Spinner with HTML

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/loading/+page.md

This snippet demonstrates how to create a loading spinner animation using DaisyUI. It shows various sizes from extra small to extra large by applying `loading-spinner` and `loading-[size]` classes to a `<span>` element, providing a visual indicator for ongoing processes.

```html
<span class="$$loading $$loading-spinner $$loading-xs"></span>
<span class="$$loading $$loading-spinner $$loading-sm"></span>
<span class="$$loading $$loading-spinner $$loading-md"></span>
<span class="$$loading $$loading-spinner $$loading-lg"></span>
<span class="$$loading $$loading-spinner $$loading-xl"></span>
```

--------------------------------

### HTML for DaisyUI Badges with Themed Colors

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/badge/+page.md

Shows how to apply different color themes (primary, secondary, accent, neutral, info, success, warning, error) to badges using corresponding utility classes. These classes integrate with DaisyUI's theme system.

```HTML
<div class="$$badge $$badge-primary">Primary</div>
<div class="$$badge $$badge-secondary">Secondary</div>
<div class="$$badge $$badge-accent">Accent</div>
<div class="$$badge $$badge-neutral">Neutral</div>
<div class="$$badge $$badge-info">Info</div>
<div class="$$badge $$badge-success">Success</div>
<div class="$$badge $$badge-warning">Warning</div>
<div class="$$badge $$badge-error">Error</div>
```

--------------------------------

### DaisyUI Input: Applying Color Styles

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/input/+page.md

This snippet demonstrates how to apply various color themes (neutral, primary, secondary, accent, info, success, warning, error) to standard HTML input fields using DaisyUI's `input` and color-specific utility classes. These classes provide consistent visual feedback for different input states and purposes.

```html
<input type="text" placeholder="neutral" class="$$input $$input-neutral" />
<input type="text" placeholder="Primary" class="$$input $$input-primary" />
<input type="text" placeholder="Secondary" class="$$input $$input-secondary" />
<input type="text" placeholder="Accent" class="$$input $$input-accent" />

<input type="text" placeholder="Info" class="$$input $$input-info" />
<input type="text" placeholder="Success" class="$$input $$input-success" />
<input type="text" placeholder="Warning" class="$$input $$input-warning" />
<input type="text" placeholder="Error" class="$$input $$input-error" />
```

--------------------------------

### Create a DaisyUI Table with Pinned Rows and Columns

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/table/+page.md

This HTML snippet demonstrates how to construct a responsive table using DaisyUI classes. It features `table-pin-rows` and `table-pin-cols` for fixed headers and the first column, and `overflow-x-auto` for horizontal scrolling on smaller screens. The `table-xs` class applies extra small styling, making it suitable for dense data displays.

```HTML
<div class="overflow-x-auto h-96 w-96">
  <table class="table table-xs table-pin-rows table-pin-cols">
    <thead>
      <tr>
        <th></th>
        <td>Name</td>
        <td>Job</td>
        <td>company</td>
        <td>location</td>
        <td>Last Login</td>
        <td>Favorite Color</td>
        <th></th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <th>1</th>
        <td>Cy Ganderton</td>
        <td>Quality Control Specialist</td>
        <td>Littel, Schaden and Vandervort</td>
        <td>Canada</td>
        <td>12/16/2020</td>
        <td>Blue</td>
        <th>1</th>
      </tr>
      <tr>
        <th>2</th>
        <td>Hart Hagerty</td>
        <td>Desktop Support Technician</td>
        <td>Zemlak, Daniel and Leannon</td>
        <td>United States</td>
        <td>12/5/2020</td>
        <td>Purple</td>
        <th>2</th>
      </tr>
      <tr>
        <th>3</th>
        <td>Brice Swyre</td>
        <td>Tax Accountant</td>
        <td>Carroll Group</td>
        <td>China</td>
        <td>8/15/2020</td>
        <td>Red</td>
        <th>3</th>
      </tr>
      <tr>
        <th>4</th>
        <td>Marjy Ferencz</td>
        <td>Office Assistant I</td>
        <td>Rowe-Schoen</td>
        <td>Russia</td>
        <td>3/25/2021</td>
        <td>Crimson</td>
        <th>4</th>
      </tr>
      <tr>
        <th>5</th>
        <td>Yancy Tear</td>
        <td>Community Outreach Specialist</td>
        <td>Wyman-Ledner</td>
        <td>Brazil</td>
        <td>5/22/2020</td>
        <td>Indigo</td>
        <th>5</th>
      </tr>
      <tr>
        <th>6</th>
        <td>Irma Vasilik</td>
        <td>Editor</td>
        <td>Wiza, Bins and Emard</td>
        <td>Venezuela</td>
        <td>12/8/2020</td>
        <td>Purple</td>
        <th>6</th>
      </tr>
      <tr>
        <th>7</th>
        <td>Meghann Durtnal</td>
        <td>Staff Accountant IV</td>
        <td>Schuster-Schimmel</td>
        <td>Philippines</td>
        <td>2/17/2021</td>
        <td>Yellow</td>
        <th>7</th>
      </tr>
      <tr>
        <th>8</th>
        <td>Sammy Seston</td>
        <td>Accountant I</td>
        <td>O'Hara, Welch and Keebler</td>
        <td>Indonesia</td>
        <td>5/23/2020</td>
        <td>Crimson</td>
        <th>8</th>
      </tr>
      <tr>
        <th>9</th>
        <td>Lesya Tinham</td>
        <td>Safety Technician IV</td>
        <td>Turner-Kuhlman</td>
        <td>Philippines</td>
        <td>2/21/2021</td>
        <td>Maroon</td>
        <th>9</th>
      </tr>
      <tr>
        <th>10</th>
        <td>Zaneta Tewkesbury</td>
        <td>VP Marketing</td>
        <td>Sauer LLC</td>
        <td>Chad</td>
        <td>6/23/2020</td>
        <td>Green</td>
        <th>10</th>
      </tr>
      <tr>
        <th>11</th>
        <td>Andy Tipple</td>
        <td>Librarian</td>
        <td>Hilpert Group</td>
        <td>Poland</td>
        <td>7/9/2020</td>
        <td>Indigo</td>
        <th>11</th>
      </tr>
      <tr>
        <th>12</th>
        <td>Sophi Biles</td>
        <td>Recruiting Manager</td>
        <td>Gutmann Inc</td>
        <td>Indonesia</td>
        <td>2/12/2021</td>
        <td>Maroon</td>
        <th>12</th>
      </tr>
      <tr>
        <th>13</th>
        <td>Florida Garces</td>
        <td>Web Developer IV</td>
        <td>Gaylord, Pacocha and Baumbach</td>
        <td>Poland</td>
        <td>5/31/2020</td>
        <td>Purple</td>
        <th>13</th>
      </tr>
      <tr>
        <th>14</th>
        <td>Maribeth Popping</td>
        <td>Analyst Programmer</td>
        <td>Deckow-Pouros</td>
        <td>Portugal</td>
        <td>4/27/2021</td>
        <td>Aquamarine</td>
        <th>14</th>
      </tr>
      <tr>
        <th>15</th>
        <td>Moritz Dryburgh</td>
        <td>Dental Hygienist</td>
        <td>Schiller, Cole and Hackett</td>
        <td>Sri Lanka</td>
        <td>8/8/2020</td>
        <td>Crimson</td>
        <th>15</th>
      </tr>
      <tr>
        <th>16</th>
        <td>Reid Semiras</td>
        <td>Teacher</td>
        <td>Sporer, Sipes and Rogahn</td>
        <td>Poland</td>
        <td>7/30/2020</td>
        <td>Green</td>
        <th>16</th>
      </tr>
      <tr>
        <th>17</th>
        <td>Alec Lethby</td>
        <td>Teacher</td>
        <td>Reichel, Glover and Hamill</td>
        <td>China</td>
        <td>2/28/2021</td>
        <td>Khaki</td>
        <th>17</th>
      </tr>
      <tr>
        <th>18</th>
        <td>Aland Wilber</td>
        <td>Quality Control Specialist</td>
        <td>Kshlerin, Rogahn and Swaniawski</td>
        <td>Czech Republic</td>
        <td>9/29/2020</td>
        <td>Purple</td>
        <th>18</th>
      </tr>
      <tr>
        <th>19</th>
        <td>Teddie Duerden</td>
        <td>Staff Accountant III</td>
        <td>Pouros, Ullrich and Windler</td>
        <td>France</td>
        <td>10/27/2020</td>
        <td>Aquamarine</td>
        <th>19</th>
      </tr>
    </tbody>
  </table>
</div>
```

--------------------------------

### Add CSS build script to package.json

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/docs/install/htmx/+page.md

Adds a 'build:css' script to your project's package.json file. This script uses the Tailwind CSS CLI to process 'app.css' and output the compiled CSS to 'public/output.css', making it ready for use in your HTML.

```json
{
  "scripts": {
    "build:css": "npx @tailwindcss/cli -i app.css -o public/output.css"
  }
}
```

--------------------------------

### SvelteKit HTML Content Injection Placeholders

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/app.html

These placeholders are used by SvelteKit to inject the generated HTML content into the main document during server-side rendering or client-side hydration. '%sveltekit.head%' is replaced with the content of the <head> section, and '%sveltekit.body%' is replaced with the content of the <body> section, including the Svelte application's root element.

```html
%sveltekit.head%
%sveltekit.body%
```

--------------------------------

### File Input with Ghost Style

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/src/routes/(routes)/components/file-input/+page.md

Shows how to apply a 'ghost' style to the file input, which typically means a more subtle or transparent appearance, by adding the 'file-input-ghost' class.

```HTML
<input type="file" class="$$file-input $$file-input-ghost" />
```

--------------------------------

### DaisyUI Diff Component HTML Syntax

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/static/llms.txt

Shows the basic HTML structure for a DaisyUI diff component, used for side-by-side comparisons. It includes placeholders for the two items being compared and the resizer element.

```html
<div class="diff">
  <div class="diff-item-1"></div>
  <div class="diff-item-2"></div>
  <div class="diff-resizer"></div>
</div>
```

--------------------------------

### DaisyUI mockup-window Component

Source: https://github.com/saadeghi/daisyui/blob/master/packages/docs/static/llms.txt

Creates a UI element styled as an operating system window. Content is placed within a child div inside the main window container.

```html
<div class="mockup-window">
  <div>{CONTENT}</div>
</div>
```