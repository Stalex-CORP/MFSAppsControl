# MFSAppsControl — user documentation

Source of the user documentation for **MFSAppsControl**, a Windows application that
watches Microsoft Flight Simulator 2024/2020 and starts or stops your add-ons for you.

📖 **[Read the documentation](https://mfsappscontrol.stalexcorp.fr/)**

The application itself lives in a separate, private repository. This one holds only
the documentation and the releases.

## Languages

Six, all complete: English (default), French, German, Spanish, Italian and Portuguese.
Pages carry a language suffix — `options.md` is English, `options.fr.md` French, and so
on — and `mkdocs-static-i18n` assembles them into one site per language.

The **French pages are the source of truth**: they are written first, and the other five
are brought in line with them.

## Building locally

```bash
pip install -r requirements-docs.txt
mkdocs serve
```

The site is published to GitHub Pages by `.github/workflows/docs.yml` on every push to
`main` that touches the documentation.

## Contributing

Corrections are welcome — a typo, a passage that reads wrong, a screenshot that no
longer matches the application. Open an issue or a pull request.

If you change a French page, say so in the pull request: the other languages have to
follow, and it is better to know it is coming than to discover the site out of step.

## Licence

Documentation and images: [CC BY 4.0](https://creativecommons.org/licenses/by/4.0/).
