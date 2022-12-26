#!/usr/bin/env sh
echo "Enter target directory name: "
read -r DIR

set -euxf

cp -av "./TemplateProjects" "$DIR"
mv "./$DIR/TemplateProjects" "$DIR/$DIR"
mv "./$DIR/$DIR/TemplateProjects.csproj" "$DIR/$DIR/$DIR.csproj"
mv "./$DIR/TemplateProjects.Tests" "$DIR/$DIR.Tests"
mv "./$DIR/$DIR.Tests/TemplateProjects.Tests.csproj" "$DIR/$DIR.Tests/$DIR.Tests.csproj"
