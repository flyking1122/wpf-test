<?xml version="1.0" encoding="utf-16"?>
<IteModel iteVersion="MDEModel_2.1_" sourceTool="MDE" sourceModelPath=""  modelName="ReadOnlyDP" label="ReadOnlyDP" sourceBinaryPath="" replacedInvalidIdentifiers="true" automated="false" referenceID="717eb14b-1e05-454f-84b9-9d185b87063f" comment="" previewMode="false" stateBasedTestGeneration="1" xmlns="http://mbt.ntdev.corp.microsoft.com/mde/MDEModel_2.1_.xsd">
    <StateVariables referenceID="68cc8032-739c-40fa-8a9e-2a4104193652" />
    <ModelParameters referenceID="b8a1bbd3-9494-4256-a998-558312d122d9">
        <Parameters referenceID="79eb92ab-011c-480b-bc5a-7d169784f852">
            <Parameter key_Name="RegistrationType" label="RegistrationType" key_ActionReferenceID="6217f35c-5511-48ae-820f-8c6381dd69c6" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="952e4774-db9f-4e37-be0d-83c39ba913e6">
                <ParameterValue key_Name="Regular" label="Regular" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="a29af960-765e-4282-ad3e-4b83c49a22f5" />
                <ParameterValue key_Name="Attached" label="Attached" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="2156df93-f71f-4d69-b926-e15da4ff9a18" />
            </Parameter>
            <Parameter key_Name="InheritanceContext" label="InheritanceContext" key_ActionReferenceID="6217f35c-5511-48ae-820f-8c6381dd69c6" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="d14ca509-34b6-48e2-bc6c-6f89dc39354c">
                <ParameterValue key_Name="Custom" label="Custom" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="c30736fc-b38c-4a0a-a158-9deb69a4a832" />
                <ParameterValue key_Name="Pre" label="Pre" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="5b48c8ff-e5ab-486d-ba12-a85a2c2ae6aa" />
            </Parameter>
            <Parameter key_Name="InheritanceBehaviour" label="InheritanceBehaviour" key_ActionReferenceID="6217f35c-5511-48ae-820f-8c6381dd69c6" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="c3a86012-5537-4d14-a171-632e8ef75e43">
                <ParameterValue key_Name="Default" label="Default" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="8a5da6b6-586b-467e-961f-f2a24baee996" />
                <ParameterValue key_Name="Modified" label="Modified" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="192794bd-63e1-4834-8145-0ad5125eed22" />
            </Parameter>
            <Parameter key_Name="ElementTree" label="ElementTree" key_ActionReferenceID="6217f35c-5511-48ae-820f-8c6381dd69c6" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="9c214d3c-a565-44e2-b05a-5f1cf91ed4c6">
                <ParameterValue key_Name="Logical" label="Logical" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="f3772308-4f3a-4bb9-9b3b-7ab0d0098ffc" />
                <ParameterValue key_Name="Visual" label="Visual" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="c7432ed2-6d9c-4e1d-a063-c6e4ee2f3fc9" />
            </Parameter>
            <Parameter key_Name="Action" label="Action" key_ActionReferenceID="6217f35c-5511-48ae-820f-8c6381dd69c6" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="a7667733-e206-444e-9c0b-298e294be402">
                <ParameterValue key_Name="OverrideMetadata" label="OverrideMetadata" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="02ef2013-6da7-47af-93e7-d19b6d879d76" />
                <ParameterValue key_Name="Clear" label="Clear" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="424319c0-ce20-4f1a-8048-1590525c7005" />
                <ParameterValue key_Name="Set" label="Set" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="e4031402-a94d-42dd-8869-57baa611c3b6" />
                <ParameterValue key_Name="Get" label="Get" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="84e25695-4771-4938-bedc-234497bbacf0" />
            </Parameter>
        </Parameters>
        <ParameterCombinationRules seed="1" referenceID="5c71b3e0-e09d-4033-93d5-bb9b49245e5e">
            <ParameterCluster key_Name="CombinationGroup# 0" label="CombinationGroup# 0" comment="" combinatoryType="3" include="true" combinatoryOrder="2" referenceID="de708753-50d0-4e53-b6b7-950111671767">
                <ParameterClusterElement key_ParameterReferenceID="952e4774-db9f-4e37-be0d-83c39ba913e6" key_ModelReferenceID="" referenceID="6e2edc42-f203-46b7-98b6-c9ad95eb492e" />
                <ParameterClusterElement key_ParameterReferenceID="d14ca509-34b6-48e2-bc6c-6f89dc39354c" key_ModelReferenceID="" referenceID="985f40ca-d073-4f27-a637-288c0d07bd17" />
                <ParameterClusterElement key_ParameterReferenceID="c3a86012-5537-4d14-a171-632e8ef75e43" key_ModelReferenceID="" referenceID="23f4601d-2ee3-46ef-9d0c-6531779d2f31" />
                <ParameterClusterElement key_ParameterReferenceID="9c214d3c-a565-44e2-b05a-5f1cf91ed4c6" key_ModelReferenceID="" referenceID="e331f2de-a85a-41b6-938c-8250985da737" />
                <ParameterClusterElement key_ParameterReferenceID="a7667733-e206-444e-9c0b-298e294be402" key_ModelReferenceID="" referenceID="baa6c888-4cb7-4811-aadc-ead205fce43c" />
            </ParameterCluster>
        </ParameterCombinationRules>
    </ModelParameters>
    <Actions referenceID="4265da80-ea3c-4826-b475-e93ade852567">
        <Action key_Name="Setup" label="Setup" comment="" weight="1" disabled="false" defaultClusterReferenceID="" uiPersistentID="" uiPattern="" uiMethod="" automated="false" referenceID="6217f35c-5511-48ae-820f-8c6381dd69c6">
            <ActionParameters referenceID="3628cabd-ba14-4e5c-9e57-d072a3b72c92">
                <ActionParameter key_ActionParameterReferenceID="952e4774-db9f-4e37-be0d-83c39ba913e6" referenceID="51058a13-2267-4ca1-ab9f-645d0dc4ec5c" />
                <ActionParameter key_ActionParameterReferenceID="d14ca509-34b6-48e2-bc6c-6f89dc39354c" referenceID="5bcca856-fc01-4d50-8450-41ed5521ede4" />
                <ActionParameter key_ActionParameterReferenceID="c3a86012-5537-4d14-a171-632e8ef75e43" referenceID="944cd87e-a747-437f-8cfb-1862a2633add" />
                <ActionParameter key_ActionParameterReferenceID="9c214d3c-a565-44e2-b05a-5f1cf91ed4c6" referenceID="b0327550-fd15-4e3b-aa5d-1c3b8daa684a" />
                <ActionParameter key_ActionParameterReferenceID="a7667733-e206-444e-9c0b-298e294be402" referenceID="badb38c7-cba8-4236-9143-1f955315f3a8" />
            </ActionParameters>
        </Action>
    </Actions>
    <TransitionRules referenceID="1b7bf3e1-4127-4a21-9104-3543677dbcff" />
    <EntryPoints seed="1" referenceID="853f51ee-dd0a-4f30-b6bc-2b4deb0e98b6" />
    <AssertionRules referenceID="545dfb80-326b-446a-bd17-f630c356e223" />
    <ModelInfo overview="" constructionInfo="" referenceID="99035480-7b66-48ad-9dd2-36f9ccf153f2" />
    <ModelReferences referenceID="c850c872-c877-4c90-84f2-b7c2074f13b9" />
    <ModelLinkRules referenceID="8138c264-005a-406b-8213-b68eac744f22" />
    <TestQueries referenceID="03f65143-e749-48da-8c40-5b66df1a9f0d">
        <TestQuery key_Name="ReadOnlyDPs" label="ReadOnlyDPs" testOutputFilePathName="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-16&quot;?&gt;&#xD;&#xA;&lt;StandAloneLocation xmlns:xsd=&quot;http://www.w3.org/2001/XMLSchema&quot; xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot;&gt;&#xD;&#xA;  &lt;ModelPathName&gt;D:\NT\testsrc\windowstestdata\redist\client\wcptests\core\bvt\propertyengine\ReadOnlyDPs\ReadOnlyDPModel.mbt&lt;/ModelPathName&gt;&#xD;&#xA;  &lt;TestCaseFileName&gt;D:\NT\testsrc\windowstestdata\redist\client\wcptests\core\bvt\propertyengine\ReadOnlyDPs\ReadOnlyDPs.xtc&lt;/TestCaseFileName&gt;&#xD;&#xA;&lt;/StandAloneLocation&gt;" comment="" isStateless="true" referenceID="accba954-1404-44fb-8fa4-200b1fc3e1a3" maxTestCases="1000" applyFilters="true" testOutputLocationType="Microsoft.Ite.StandAloneInterface.StandAloneLocation,Microsoft.Ite.StandAloneTcmInterface, Version=2.1.2005.0, Culture=neutral, PublicKeyToken=null~" externalDataXml="" externalDataType="" disabled="false">
            <TestPattern seed="1" referenceID="baee7e6d-47b8-4e33-b72f-fe5c05578b04">
                <TestPatternElement testPatternElementType="0" modelReferenceID="717eb14b-1e05-454f-84b9-9d185b87063f" referenceID="e3968c36-221e-4ff4-b2a7-8cd5139a1a9f">
                    <ActionTestPatternElement actionReferenceID="6217f35c-5511-48ae-820f-8c6381dd69c6" referenceID="71fee830-bbcb-4277-a215-89e02933442a" />
                </TestPatternElement>
            </TestPattern>
        </TestQuery>
    </TestQueries>
    <TestFilters referenceID="d5c1187c-b980-4a21-b342-dfe7083e28ad" />
    <CustomData referenceID="bc95e4d7-25a1-428f-8190-cfa8d743aec0" />
</IteModel>