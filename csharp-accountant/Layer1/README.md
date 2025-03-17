# High Points

The layer 1 is a placeholder for while we work the more important portions of the project.

Today: Have a CSV file saved to disk. The folder location should be the Account (and if you are working against a sub account, another folder lower) and inside of the file, if a text string specifying the header version, and then the next line is the data.

Essentially, a 2 line CSV file.

Tomorrow: Sharing of files among several slices, and we have one slice be the master for all changes, and other slices sync with that slice. By this point, the file is encrypted and MAC (message authenticated), allowing for any changes to be found.

(Ignoring the encryption problem. We should not have these files retain permanent data on the basis that we will waste 4K of space, less the size of the file. Since these files will be about 1K of space, this will not be efficient.)

I am considering using these as scratch, and then having them rollup into a master file at periodic times...
