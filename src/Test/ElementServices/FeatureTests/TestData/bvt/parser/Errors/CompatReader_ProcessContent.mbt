<?xml version="1.0" encoding="utf-16"?>
<IteModel iteVersion="MDEModel_2.1_" sourceTool="MDE" sourceModelPath=""  modelName="CompatReaderModel" label="CompatReaderModel" sourceBinaryPath="" replacedInvalidIdentifiers="true" automated="false" referenceID="85ceca4e-fac5-4428-b70a-bc410f33eeac" comment="" previewMode="false" stateBasedTestGeneration="1" xmlns="http://mbt.ntdev.corp.microsoft.com/mde/MDEModel_2.1_.xsd">
    <StateVariables referenceID="3f92dbba-6064-4fe8-82b5-e4a51390ad42" />
    <ModelParameters referenceID="61b5b38a-f42f-4a23-852e-54ea71572442">
        <Parameters referenceID="20dd3eb5-60d8-4aaf-9b4b-c32862cfece4">
            <Parameter key_Name="Scenario" label="Scenario" key_ActionReferenceID="8f48a7e4-2900-442d-a56f-b4b79f97a838" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="89f1fc61-81ea-44e7-a08a-cc528fe3fabb">
                <ParameterValue key_Name="Comma_Separated_Value" label="Comma_Separated_Value" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="11235a3c-fef2-4b82-acca-9f255e1adecb" />
                <ParameterValue key_Name="Repeatition_In_Value" label="Repeatition_In_Value" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="cdd456b1-45b5-4eb4-855f-f95337b1ff81" />
                <ParameterValue key_Name="ProcessContent_Without_Ignorable" label="ProcessContent_Without_Ignorable" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="6c51b2d8-cde2-4464-a44b-d0522f9e68e9" />
                <ParameterValue key_Name="Non_Ignorable_Namespace_In_Value" label="Non_Ignorable_Namespace_In_Value" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="a90c1f11-85cc-43ce-87b0-2a8c228fe815" />
            </Parameter>
        </Parameters>
        <ParameterCombinationRules seed="1" referenceID="d555775a-ca26-456f-8191-7eb0ad96348f">
            <ParameterCluster key_Name="CombinationGroup# 0" label="CombinationGroup# 0" comment="" combinatoryType="0" include="true" combinatoryOrder="0" referenceID="86574c6d-80ce-4202-aeba-cb4f0055d0ff">
                <ParameterClusterElement key_ParameterReferenceID="89f1fc61-81ea-44e7-a08a-cc528fe3fabb" key_ModelReferenceID="" referenceID="fb2d2652-32b7-469c-8dfd-d10133167cea" />
            </ParameterCluster>
        </ParameterCombinationRules>
    </ModelParameters>
    <Actions referenceID="7c11f224-e162-4b9f-bcd5-3cbc27116f84">
        <Action key_Name="TestProcessContent" label="TestProcessContent" comment="" weight="1" disabled="false" defaultClusterReferenceID="" uiPersistentID="" uiPattern="" uiMethod="" automated="false" referenceID="8f48a7e4-2900-442d-a56f-b4b79f97a838">
            <ActionParameters referenceID="c4e8056c-6ac0-4cab-b844-6c0ba4deba19">
                <ActionParameter key_ActionParameterReferenceID="89f1fc61-81ea-44e7-a08a-cc528fe3fabb" referenceID="430f30c5-e77c-412e-a282-c16e418879d2" />
            </ActionParameters>
        </Action>
    </Actions>
    <TransitionRules referenceID="2133164e-dcff-44ef-a965-3525ea6d8d64" />
    <EntryPoints seed="1" referenceID="b67a9861-4f7f-4bc8-a249-ce1b14059543" />
    <AssertionRules referenceID="3456359f-5ef6-436b-b4f8-ff62f3e64a6c" />
    <ModelInfo overview="" constructionInfo="" referenceID="d071ed90-d70a-4691-acdc-fcc426747ec0" />
    <ModelReferences referenceID="f5ddf8f6-4ab9-4c41-8239-838d37ec8176" />
    <ModelLinkRules referenceID="371a886e-125a-4e05-88ca-56b59414038c" />
    <TestQueries referenceID="a0314dd9-1feb-46e4-9b26-002f0b2d13f3">
        <TestQuery key_Name="TestProcessContent" label="TestProcessContent" testOutputFilePathName="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-16&quot;?&gt;&#xD;&#xA;&lt;StandAloneLocation xmlns:xsd=&quot;http://www.w3.org/2001/XMLSchema&quot; xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot;&gt;&#xD;&#xA;  &lt;ModelPathName&gt;D:\Documents and Settings\snijsure\Desktop\CompatReader_ProcessContent.mbt&lt;/ModelPathName&gt;&#xD;&#xA;  &lt;TestCaseFileName&gt;F:\nt\testsrc\windowstestdata\redist\client\wcptests\core\bvt\parser\Errors\TestProcessContent.xtc&lt;/TestCaseFileName&gt;&#xD;&#xA;&lt;/StandAloneLocation&gt;" comment="" isStateless="true" referenceID="3f8387f2-e064-450f-9fe9-33826adedd5a" maxTestCases="0" applyFilters="true" testOutputLocationType="Microsoft.Ite.StandAloneInterface.StandAloneLocation,Microsoft.Ite.StandAloneTcmInterface, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null~" externalDataXml="" externalDataType="" disabled="false">
            <TestPattern seed="1" referenceID="6fd5ef99-edaf-4faf-8619-1db68ed7c8b4">
                <TestPatternElement testPatternElementType="0" modelReferenceID="85ceca4e-fac5-4428-b70a-bc410f33eeac" referenceID="6bfaa506-0892-49f8-913f-66c72f3c7219">
                    <ActionTestPatternElement actionReferenceID="8f48a7e4-2900-442d-a56f-b4b79f97a838" referenceID="32997829-7a0e-4f10-8d24-6edbe40fa51b">
                        <ParameterTestPatternElement key_ParameterReferenceID="89f1fc61-81ea-44e7-a08a-cc528fe3fabb" parameterValueReferenceID="" lowWeight="0" highWeight="0" validFilter="0" automatedFilter="0" bucketFilter="" referenceID="fe536e85-3471-40a8-b957-0467fba64d73" />
                    </ActionTestPatternElement>
                </TestPatternElement>
            </TestPattern>
        </TestQuery>
    </TestQueries>
    <TestFilters referenceID="34bee5dd-947d-47f3-be94-8125aa14945a" />
    <CustomData referenceID="67fd9783-957e-4094-ad3c-227aabf92d9a" />
</IteModel>