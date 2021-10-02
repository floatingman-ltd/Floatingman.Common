# Floatingman.Common

- ![.NET Core](https://github.com/floatingman-ltd/Floatingman.Common/workflows/any-push.yml/badge.svg?branch=main)
- [![Coverage Status](https://coveralls.io/repos/github/floatingman-ltd/Floatingman.Common/badge.svg?branch=root)](https://coveralls.io/github/floatingman-ltd/Floatingman.Common?branch=root)

Utilities and thingies that I use all the time

## Actions, Branches, Versions and Releases

> This is a release strategy that works for Nuget packages which must be versioned.  At the same time a heavy weight process like _gitflow_ is a little overboard.
### Branches

There is one branch of interest, this is the `main` branch.  The tip of his branch is the published version of the public nuget package.  Furthermore, when a PR is opened from any branch to `main` an internal or private nuget package is created.

All other branches are development branches.  At any given point a developer may create an internal or private version of the nuget package.  

### Actions

#### Push to any branch

This should trigger a linting, build, test and coverage check.

#### Pull request to main

This should trigger a publish to private nuget, this relese should be marked as prerelease.

#### Push to main

THis should trigger a publish to nuget.
