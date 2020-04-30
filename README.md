# auto-save-vs-extension
An extension that automatically saves the file as you're working on it.

There are 3 conditions when changed file/s is saved.
- The 5 seconds (default) have elapsed since the last change.
- The file loses focus.
- The solution loses focus. All the changed files are saved.

| Condition                                                   | Respects ignored file types | Can be disabled? |
| ---                                                         | ---                         | ---              |
| The 5 seconds (default) have elapsed since the last change. | Yes                         | Yes              |
| The file loses focus.                                       | Yes                         | Yes              |
| The solution loses focus. All the changed files are saved.  | Yes                         | Yes              |

### Configurable Settings
* The time delay can be configured from the options panel. <img src="https://github.com/hrai/auto-save-vs-extension/blob/master/options.png">
* If you want to exclude some files from auto-saving, you can supply a list of comma-separated file extensions such as '*vb,json,config*'
* If you want to save all the modified files when Visual Studio loses focus, then enable this to true. Set to True by default.
