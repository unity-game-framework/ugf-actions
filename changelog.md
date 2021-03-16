# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [3.0.0-preview](https://github.com/unity-game-framework/ugf-actions/releases/tag/3.0.0-preview) - 2021-03-16  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-actions/milestone/3?closed=1)  
    

### Changed

- Replace context using UGF.RuntimeTools package ([#14](https://github.com/unity-game-framework/ugf-actions/pull/14))  
    - Remove and replace `IActionContext` interface by `IContext` from _UGF.RuntimeTools_ package.
- Update package registry ([#11](https://github.com/unity-game-framework/ugf-actions/pull/11))  
    - Update package publish registry.

### Removed

- Remove IActionDescribed interface ([#13](https://github.com/unity-game-framework/ugf-actions/pull/13))  
    - Remove `IActionDescribed` interface and replaced by `IDescribed`.

## [2.0.0](https://github.com/unity-game-framework/ugf-actions/releases/tag/2.0.0) - 2021-01-04  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-actions/milestone/2?closed=1)  
    

### Changed

- Replace Func with ActionContextPredicate delegate in IActionContext ([#6](https://github.com/unity-game-framework/ugf-actions/pull/6))  
    - Add `ActionContextPredicate` delegate to use with `IActionContext`.
    - Change `IActionContext.TryGet()` predicate argument type to `ActionContextPredicate` delegate.

## [1.0.1](https://github.com/unity-game-framework/ugf-actions/releases/tag/1.0.1) - 2020-12-06  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-actions/milestone/1?closed=1)  
    

### Changed

- Change actions and systems to display full type name in profiler ([#3](https://github.com/unity-game-framework/ugf-actions/pull/3))  
    - Change to display full type name instead of name only.

## [1.0.0](https://github.com/unity-game-framework/ugf-actions/releases/tag/1.0.0) - 2020-12-05  

### Release Notes

- No release notes.


