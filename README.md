# auto-save-vs-extension
An extension that automatically saves the file as you're working on it.

There are 3 conditions when changed file/s is saved.

| Condition                                                   | Respects ignored file types | Can be disabled? |
| ---                                                         | ---                         | ---              |
| The 5 seconds (default) have elapsed since the last change. | Yes                         | No               |
| The file loses focus.                                       | Yes                         | No               |
| Visual Studio loses focus. All the changed files are saved. | No                          | Yes              |

### Configurable Settings
* The time delay can be configured from the options panel. <img src="https://github.com/hrai/auto-save-vs-extension/blob/master/options.png">
* If you want to exclude some files from auto-saving, you can supply a list of comma-separated file extensions such as '*vb,json,config*'
* If you want to save all the modified files when Visual Studio loses focus, then enable this to true. Set to True by default.
