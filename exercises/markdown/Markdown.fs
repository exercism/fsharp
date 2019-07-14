module Markdown

let rec parse (markdown: string) =
   let mutable html = ""
   let mutable remainder = markdown
   let mutable isList = false

   let lines = remainder.Split('\n')

   for i = 0 to lines.Length - 1 do
       
       if lines.[i].[0] = '*' then
           if not isList then  
               html <- html + "<ul>"
               isList <- true

           html <- html + "<li>"

           let mutable line = lines.[i].[2..]     
           let mutable __pos = line.IndexOf "__"

           let notusep = line.StartsWith "__" || line.StartsWith "_"

           while __pos > -1 do                
               let mutable __pos' = if __pos >= (line.Length - 2) then -1 else line.IndexOf("__", __pos + 2)

               if __pos' > -1 then                                        
                   if __pos + 2 >= (line.Length - 1) then                     
                       line <- line.[0.. __pos - 1] + "<strong>" + line.[__pos + 2 .. __pos' - 1] + "</strong>"
                       __pos <- __pos' + 1
                   else
                       line <- line.[0.. __pos - 1] + "<strong>" + line.[__pos + 2 .. __pos' - 1] + "</strong>" + line.[__pos' + 2 ..]
                       __pos <- __pos' + 1
               else
                   __pos <- -1

           __pos <- line.IndexOf "_"

           while __pos > -1 do                
               let mutable __pos' = if __pos >= (line.Length - 1) then -1 else line.IndexOf("_", __pos + 1)

               if __pos' > -1 then                                        
                   if __pos + 1 >= (line.Length - 1) then                     
                       line <- line.[0.. __pos - 1] + "<em>" + line.[__pos + 1 .. __pos' - 1] + "</em>"
                       __pos <- __pos' + 1
                   else
                       line <- line.[0.. __pos - 1] + "<em>" + line.[__pos + 1 .. __pos' - 1] + "</em>" + line.[__pos' + 1 ..]
                       __pos <- __pos' + 1
               else
                   __pos <- -1
                   
           html <- html + line 

           html <- html + "</li>"          

       elif lines.[i].[0] = '#' then
           if lines.[i].[0..6] = "###### " then
               html <- html + "<h6>" + lines.[i].[7..] + "</h6>"
           elif lines.[i].[0..5] = "##### " then
               html <- html + "<h5>" + lines.[i].[6..] + "</h5>"
           elif lines.[i].[0..4] = "#### " then
               html <- html + "<h4>" + lines.[i].[5..] + "</h4>"
           elif lines.[i].[0..3] = "### " then
               html <- html + "<h3>" + lines.[i].[4..] + "</h3>"
           elif lines.[i].[0..2] = "## " then
               html <- html + "<h2>" + lines.[i].[3..] + "</h2>"
           else
               html <- html + "<h1>" + lines.[i].[2..] + "</h1>"
       else
           if isList then  
               html <- html + "</ul>"
               isList <- false
           
           let mutable line = lines.[i]            
           let mutable __pos = line.IndexOf "__"

           while __pos > -1 do                
               let mutable __pos' = if __pos >= (line.Length - 2) then -1 else line.IndexOf("__", __pos + 2)

               if __pos' > -1 then                                        
                   if __pos + 2 >= (line.Length - 1) then                     
                       line <- line.[0.. __pos - 1] + "<strong>" + line.[__pos + 2 .. __pos' - 1] + "</strong>"
                       __pos <- __pos' + 1
                   else
                       line <- line.[0.. __pos - 1] + "<strong>" + line.[__pos + 2 .. __pos' - 1] + "</strong>" + line.[__pos' + 2 ..]
                       __pos <- __pos' + 1
               else
                   __pos <- -1

           __pos <- line.IndexOf "_"

           while __pos > -1 do                
               let mutable __pos' = if __pos >= (line.Length - 1) then -1 else line.IndexOf("_", __pos + 1)

               if __pos' > -1 then                                        
                   if __pos + 1 >= (line.Length - 1) then                     
                       line <- line.[0.. __pos - 1] + "<em>" + line.[__pos + 1 .. __pos' - 1] + "</em>"
                       __pos <- __pos' + 1
                   else
                       line <- line.[0.. __pos - 1] + "<em>" + line.[__pos + 1 .. __pos' - 1] + "</em>" + line.[__pos' + 1 ..]
                       __pos <- __pos' + 1
               else
                   __pos <- -1

           html <- html + "<p>" + line + "</p>"

   if isList then
       html <- html + "</ul>"

   html