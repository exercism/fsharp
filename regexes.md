# Remove fact attributes

\[<Fact>(.+)?\]\n

# Remove open modules

```
\n*open (.+)\n
```

# Remove modules

```
module (.+)\n
```

# Remove dirs

find . -name '.approaches' -execdir rm -rf {} \;
find . -name '.config' -execdir rm -rf {} \;
find . -name '.docs' -execdir rm -rf {} \;
find . -name '.meta' -execdir rm -rf {} \;
find . -name '\*.fsproj' -execdir rm -f {} \;

# Double numeric argument - single numeric output

-- $1
-- ==
-- input { $3 $4 }
-- output { $5 }

let `(.+?)` \(\) =
\s+(\w+) (-?\d+(\.\d+)?) (-?\d+(\.\d+)?) \|> should equal (-?\d+(\.\d+)?)

# Single argument - single output

let `(.+?)` \(\) =
\s+(\w+) (-?\d+(\.\d+)?) \|> should equal (.+)

-- $1
-- ==
-- input { $3 }
-- output { $4 }

# Single string argument - single numeric output

let `(.+?)` \(\) =
\s+(\w+) ("[^"]+") \|> should equal (-?\d+(\.\d+)?)

-- $1
-- ==
-- input { $3 }
-- output { $4 }

# Single string argument - single string output

let `(.+?)` \(\) =
\s+(\w+) ("[^"]+") \|> should equal ("[^"]+")

-- $1
-- ==
-- input { $3 }
-- output { $4 }

# Double string argument - single output

let `(.+?)` \(\) =
\s+(\w+) ("[^"]+") ("[^"]+") \|> should equal (.+)

-- $1
-- ==
-- input { $3 $4 }
-- output { $5 }

# Remove comment

// This file was created manually(.+)\n\nmodule(.+)\n+

# Rename files

```ruby
Dir.glob("**/*Tests.fs") {|dir| FileUtils.mv(dir, dir.split("/")[0] + "/test.fut")}
 Dir.glob("**/*.fs") {|dir| FileUtils.mv(dir, dir.split("/")[0] + "/" + dir.split("/")[0].tr("-","_") + ".fut")}
```

# Add import

```ruby
Dir.glob("**/*Tests.fs") {|dir| File.write(dir, File.readlines(dir).prepend(['import "' + dir.split("/")[0].tr("-", "\_") + '"' + "\n\n" ]).join)}
```

# Fixup arrays

(["\d]); (["\d])

$1, $2

# Fixup decimal

```
(\d+)\.(\d+)m
```

```
$1.$2
```

# Fixup some

\(Some (.+?)\)

$1
