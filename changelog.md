# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [3.0.0-preview.4](https://github.com/unity-game-framework/ugf-actions/releases/tag/3.0.0-preview.4) - 2022-11-08  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-actions/milestone/7?closed=1)  
    

### Added

- Add action with execute handlers ([#22](https://github.com/unity-game-framework/ugf-actions/issues/22))  
    - Add `ActionExecuteList` and related classes used to implement action with multiple command handlers.

## [3.0.0-preview.3](https://github.com/unity-game-framework/ugf-actions/releases/tag/3.0.0-preview.3) - 2022-10-25  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-actions/milestone/6?closed=1)  
    

### Fixed

- Fix action class naming ([#20](https://github.com/unity-game-framework/ugf-actions/issues/20))  
    - Fix `Action<T>` class name to `ActionBase<T>`.

## [3.0.0-preview.2](https://github.com/unity-game-framework/ugf-actions/releases/tag/3.0.0-preview.2) - 2022-10-13  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-actions/milestone/5?closed=1)  
    

### Added

- Add initialize methods ([#18](https://github.com/unity-game-framework/ugf-actions/issues/18))  
    - Update dependencies: add `com.ugf.initialize` of `2.9.0` version.
    - Add `ActionBase` implementation of `Initializable` class.
    - Add `ActionSystemBase` implementation of `Initializable` class.

## [3.0.0-preview.1](https://github.com/unity-game-framework/ugf-actions/releases/tag/3.0.0-preview.1) - 2022-10-13  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-actions/milestone/4?closed=1)  
    

### Changed

- Update project ([#15](https://github.com/unity-game-framework/ugf-actions/issues/15))  
    - Update package _Unity_ version to `2022.1`.
    - Update package _API Compatibility_ to `.NET Standard 2.1`.
    - Change `ActionDescriptionBase` class name to `ActionDescription`.
    - Remove `IActionBuilder` and `IActionSystemBuilder` interfaces.

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


