# auto-save-vs-extension

A Visual Studio extension that automatically saves the file as you're working on it.

There are 3 conditions when changed file/s is saved.

| Condition                                                   | Respects ignored file types | Can be disabled? |
| ----------------------------------------------------------- | --------------------------- | ---------------- |
| The 5 seconds (default) have elapsed since the last change. | Yes                         | No               |
| The file loses focus.                                       | Yes                         | No               |
| Visual Studio loses focus. All the changed files are saved. | No                          | Yes              |

### Visual Studio Marketplace URLs

- VS2019 - https://marketplace.visualstudio.com/items?itemName=HRai.AutoSaveFileOld
- VS2022 - https://marketplace.visualstudio.com/items?itemName=HRai.AutoSaveFile

### Configurable Settings

- The time delay can be configured from the options panel. <img src="https://github.com/hrai/auto-save-vs-extension/blob/master/options.png">
- If you want to exclude some files from auto-saving, you can supply a list of comma-separated file extensions such as '_vb,json,config_'
- If you want to save all the modified files when Visual Studio loses focus, then enable this to true. Set to True by default.

## How to contribute?

### Sponsor

- [Donate/Sponsor](https://github.com/sponsors/hrai) the project

### Raise issues

- Please feel free to raise issues
- PRs are welcome! :)
