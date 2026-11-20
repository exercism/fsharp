# Security vulnerability reporting

This document describes a procedure of security vulnerability reporting
and your expectations from that procedure.

## How to report vulnerabilities

Report vulnerabilities found in this project (the `linux` folder) to [Aksima](https://github.com/Aksima)

You can probably use GitHub's "Report a vulnerability" button on Aksima's fork of `fsharp` repository (if the forked repository exists).

If there is no reaction in 24 hours (which is very likely), you are free to open a public issue.

Include steps to reproduce and potential impact in the report.

## Response expectations

Expect response in 30 days since report and vulnerability to be fixed in 1 year since report.

## What DO NOT report

Please do not report vulnerabilities with origin outside of `linux` folder.
For example, at the time of writing this document, if one run:

```bash
bin/check-code-snippets.sh
```

...the following messages appear:

```
/Exercism/fsharp/tools/CodeFenceChecker/CodeFenceChecker.fsproj : warning NU1903: Package 'Microsoft.Build.Tasks.Core' 17.4.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-h4j7-5rxr-p4wc
/Exercism/fsharp/tools/CodeFenceChecker/CodeFenceChecker.fsproj : warning NU1903: Package 'System.Security.Cryptography.Pkcs' 6.0.1 has a known high severity vulnerability, https://github.com/advisories/GHSA-555c-2p6r-68mm
/Exercism/fsharp/tools/CodeFenceChecker/CodeFenceChecker.fsproj : warning NU1902: Package 'System.Security.Cryptography.Xml' 6.0.0 has a known moderate severity vulnerability, https://github.com/advisories/GHSA-vh55-786g-wjwj
```

One can agree these messages appear when running script found in `linux` folder, but the source of these messages is outside `linux` folder.
Therefore, it is not a Linux adaptation that brings that vulnerability. The original Powershell script suffers from the same issue too.
