﻿describe("when asking if map exists for source and target without any maps for the combination", function () {

    var mapType = null;
    var result = null;

    beforeEach(function () {
        mapType = doLittle.mapping.Map;
        doLittle.mapping.Map = doLittle.Type.extend(function () { });

        var maps = doLittle.mapping.maps.createWithoutScope();
        var sourceType = doLittle.Type.extend(function () { });
        var targetType = doLittle.Type.extend(function () { });

        result = maps.hasMapFor(sourceType, targetType);
    });

    afterEach(function () {
        doLittle.mapping.Map = mapType;
    });

    it("should not have map", function () {
        expect(result).toBe(false);
    });
});