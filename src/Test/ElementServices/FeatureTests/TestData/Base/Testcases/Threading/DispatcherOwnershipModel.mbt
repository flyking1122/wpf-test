<?xml version="1.0" encoding="utf-16"?>
<IteModel iteVersion="MDEModel_2.1_" sourceTool="MDE" sourceModelPath=""  modelName="DispatcherOwnershipModel" label="DispatcherOwnershipModel" sourceBinaryPath="" replacedInvalidIdentifiers="true" automated="false" referenceID="869cf956-6c1c-42f0-8fa6-fe7c81f6678f" comment="" previewMode="false" stateBasedTestGeneration="1" xmlns="http://mbt.ntdev.corp.microsoft.com/mde/MDEModel_2.1_.xsd">
    <StateVariables referenceID="60242257-4612-4b2d-a14c-2820519e6002" />
    <ModelParameters referenceID="508a45cf-61f5-4850-bdec-0d86847013de">
        <Parameters referenceID="bc66c652-8fa3-4923-aed3-ba6674f0e800">
            <Parameter key_Name="ThreadState" label="ThreadState" key_ActionReferenceID="b8b794d9-c257-49a0-8563-2c382351c539" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="efeaef6f-c46f-4a75-a08c-992421000b2f">
                <ParameterValue key_Name="Null" label="Null" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="cb489795-f878-4936-89ef-79d33f39bdda" />
                <ParameterValue key_Name="NoStarted" label="NoStarted" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="989a486c-e76d-4e39-aa06-f76d11aaaa4f" />
                <ParameterValue key_Name="Running" label="Running" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="30d52831-a3e0-4491-9a0b-23556f7d42b2" />
                <ParameterValue key_Name="GarbagedCollected" label="GarbagedCollected" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="af5edc86-c480-4a45-b351-7c0a5f65532d" />
                <ParameterValue key_Name="Exited" label="Exited" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="d8c81fe5-a2f0-4521-97cb-f432befac417" />
            </Parameter>
            <Parameter key_Name="DispatcherState" label="DispatcherState" key_ActionReferenceID="b8b794d9-c257-49a0-8563-2c382351c539" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="8b03e11c-18e4-4019-a105-4e4ffd863f7d">
                <ParameterValue key_Name="NotRunning" label="NotRunning" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="6b2a9968-706f-45af-b586-b26d775ddf44" />
                <ParameterValue key_Name="Running" label="Running" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="69a9232d-65c3-4482-9a62-a6463bcdec6f" />
                <ParameterValue key_Name="Shutdown" label="Shutdown" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="bb93a369-32e4-4630-bcaa-a89626ab9964" />
                <ParameterValue key_Name="ShutdownStarted" label="ShutdownStarted" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="d8a09087-71cf-47d6-8d45-5ba49758ce12" />
                <ParameterValue key_Name="ShutdownFinished" label="ShutdownFinished" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="3094f970-0009-4f37-b41e-5341a3760c64" />
                <ParameterValue key_Name="NoCreated" label="NoCreated" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="159f263a-3983-4f67-8be8-51d8580a14c4" />
            </Parameter>
            <Parameter key_Name="AmountOfThreadsCalling" label="AmountOfThreadsCalling" key_ActionReferenceID="b8b794d9-c257-49a0-8563-2c382351c539" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="056e481e-4489-4be4-b4aa-7893fe57d6a0">
                <ParameterValue key_Name="Single" label="Single" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="b9251cfd-9a8d-4223-8d96-e92b49a6b3c1" />
                <ParameterValue key_Name="Multiple" label="Multiple" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="f9e873a9-8589-4b95-b6b7-56ed2048d27f" />
            </Parameter>
            <Parameter key_Name="TargetThread" label="TargetThread" key_ActionReferenceID="b8b794d9-c257-49a0-8563-2c382351c539" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="b5baa399-a936-41a9-be76-dc6e0f54bd4c">
                <ParameterValue key_Name="Current" label="Current" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="9ca2e87c-eda5-49a5-854b-1c32f30cc6f7" />
                <ParameterValue key_Name="Other" label="Other" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="1e06248a-30be-45d5-9e04-e798d02c0b8f" />
            </Parameter>
            <Parameter key_Name="AmountOfTimesCalling" label="AmountOfTimesCalling" key_ActionReferenceID="b8b794d9-c257-49a0-8563-2c382351c539" comment="" dataType="" dataGenerationType="" dataGenerationValue="" includeInGeneration="true" includeInClusters="true" automated="false" isNumericInModel="false" inOutType="0" uiPersistentID="" hidden="false" persist="false" referenceID="8b101b5e-20c6-4ee6-b717-261ef7063ea0">
                <ParameterValue key_Name="Single" label="Single" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="42b5fb81-bde7-4ac5-b846-a3d5a1121ca9" />
                <ParameterValue key_Name="Multiple" label="Multiple" weight="1" includeInGenerationType="1" resultWeight="1" comment="" automated="false" valid="true" uiPersistentID="" mileStone="" referenceID="a740a5c9-8bcf-49a4-b92b-85ad9c3e0bdb" />
            </Parameter>
        </Parameters>
        <ParameterCombinationRules seed="1" referenceID="673af1c2-be7e-47a9-bb3e-28aceefcbf7a">
            <ParameterCluster key_Name="CombinationGroup# 0" label="CombinationGroup# 0" comment="" combinatoryType="3" include="true" combinatoryOrder="3" referenceID="5ca6a070-be4e-4db9-b30b-e05f70ccd56c">
                <ParameterClusterElement key_ParameterReferenceID="efeaef6f-c46f-4a75-a08c-992421000b2f" key_ModelReferenceID="" referenceID="a149e88e-9da3-46b9-8f2b-f8ad5f2f6962" />
                <ParameterClusterElement key_ParameterReferenceID="8b03e11c-18e4-4019-a105-4e4ffd863f7d" key_ModelReferenceID="" referenceID="838b9910-9cf1-4eed-acf9-8a9fa932e2d2" />
                <ParameterClusterElement key_ParameterReferenceID="056e481e-4489-4be4-b4aa-7893fe57d6a0" key_ModelReferenceID="" referenceID="811db812-e47c-4146-98f7-1969804359d6" />
                <ParameterClusterElement key_ParameterReferenceID="b5baa399-a936-41a9-be76-dc6e0f54bd4c" key_ModelReferenceID="" referenceID="921a32bf-b25f-4d15-ba3c-976c1a0406e5" />
                <ParameterClusterElement key_ParameterReferenceID="8b101b5e-20c6-4ee6-b717-261ef7063ea0" key_ModelReferenceID="" referenceID="14f776d7-4df8-4b79-99c1-6497d5c40b70" />
            </ParameterCluster>
            <ParameterDependencyGroup key_Name="DependencyGroup# 0" label="DependencyGroup# 0" comment="" include="true" referenceID="27ea5748-e4e6-45d4-988d-1d6e4cfde907">
                <ParameterDependencyElement criteria="0" referenceID="9426d7ff-8b34-4c44-accc-129e5afdc8d7">
                    <ParameterDependencyCondition referenceID="afce7589-c672-4690-8cea-ed89a47318a8">
                        <ParameterDependencyConditionValue key_ParameterReferenceID="efeaef6f-c46f-4a75-a08c-992421000b2f" key_ParameterValueReferenceID="cb489795-f878-4936-89ef-79d33f39bdda" key_ModelReferenceID="" referenceID="9c620758-f7dd-43ee-8b13-56ca748362d5" />
                    </ParameterDependencyCondition>
                    <ParameterDependencyTerm referenceID="c95940c6-4ce6-4c23-8348-52aeaed0ce01">
                        <ParameterDependencyTermValue key_ParameterReferenceID="8b03e11c-18e4-4019-a105-4e4ffd863f7d" key_ParameterValueReferenceID="69a9232d-65c3-4482-9a62-a6463bcdec6f" key_ModelReferenceID="" referenceID="e50eb507-bbbf-4131-8213-7ff1c87ee83b" />
                    </ParameterDependencyTerm>
                </ParameterDependencyElement>
                <ParameterDependencyElement criteria="0" referenceID="d952c6e4-b8eb-4efb-9a79-4e4bb5a6c975">
                    <ParameterDependencyCondition referenceID="624e9780-9dab-49c8-8683-b4e19a6c8cdc">
                        <ParameterDependencyConditionValue key_ParameterReferenceID="efeaef6f-c46f-4a75-a08c-992421000b2f" key_ParameterValueReferenceID="cb489795-f878-4936-89ef-79d33f39bdda" key_ModelReferenceID="" referenceID="9c620758-f7dd-43ee-8b13-56ca748362d5" />
                    </ParameterDependencyCondition>
                    <ParameterDependencyTerm referenceID="7f6f945a-e72a-4642-b847-1c6471c9ff30">
                        <ParameterDependencyTermValue key_ParameterReferenceID="8b03e11c-18e4-4019-a105-4e4ffd863f7d" key_ParameterValueReferenceID="bb93a369-32e4-4630-bcaa-a89626ab9964" key_ModelReferenceID="" referenceID="0ef90378-8b89-4b01-a4eb-7194bf6064ac" />
                    </ParameterDependencyTerm>
                </ParameterDependencyElement>
                <ParameterDependencyElement criteria="0" referenceID="3ee3ba3e-bb96-48e9-9444-cdc0bcd8a88d">
                    <ParameterDependencyCondition referenceID="b524bff0-a67c-4ab6-80c1-68d223eaf60d">
                        <ParameterDependencyConditionValue key_ParameterReferenceID="efeaef6f-c46f-4a75-a08c-992421000b2f" key_ParameterValueReferenceID="cb489795-f878-4936-89ef-79d33f39bdda" key_ModelReferenceID="" referenceID="9c620758-f7dd-43ee-8b13-56ca748362d5" />
                    </ParameterDependencyCondition>
                    <ParameterDependencyTerm referenceID="e5d30fe2-5888-4c95-8445-a02aec28640f">
                        <ParameterDependencyTermValue key_ParameterReferenceID="8b03e11c-18e4-4019-a105-4e4ffd863f7d" key_ParameterValueReferenceID="d8a09087-71cf-47d6-8d45-5ba49758ce12" key_ModelReferenceID="" referenceID="124eb046-19b2-4e12-b188-d5a83fcc713d" />
                    </ParameterDependencyTerm>
                </ParameterDependencyElement>
                <ParameterDependencyElement criteria="0" referenceID="cd03fe4c-7c24-4e00-aa22-a94123facdb9">
                    <ParameterDependencyCondition referenceID="30255210-7e5e-42d8-8117-726c4657200e">
                        <ParameterDependencyConditionValue key_ParameterReferenceID="efeaef6f-c46f-4a75-a08c-992421000b2f" key_ParameterValueReferenceID="cb489795-f878-4936-89ef-79d33f39bdda" key_ModelReferenceID="" referenceID="9c620758-f7dd-43ee-8b13-56ca748362d5" />
                    </ParameterDependencyCondition>
                    <ParameterDependencyTerm referenceID="1ca17421-ab9f-4c8d-9dfc-1a43bcdc26df">
                        <ParameterDependencyTermValue key_ParameterReferenceID="8b03e11c-18e4-4019-a105-4e4ffd863f7d" key_ParameterValueReferenceID="3094f970-0009-4f37-b41e-5341a3760c64" key_ModelReferenceID="" referenceID="81ca46ec-51cd-4b24-ae55-1c614156caa8" />
                    </ParameterDependencyTerm>
                </ParameterDependencyElement>
                <ParameterDependencyElement criteria="0" referenceID="6d80e642-e01e-401a-a9cc-a1771fdfad91">
                    <ParameterDependencyCondition referenceID="3e7ca859-d641-4daf-ac6f-7c67fce47805">
                        <ParameterDependencyConditionValue key_ParameterReferenceID="efeaef6f-c46f-4a75-a08c-992421000b2f" key_ParameterValueReferenceID="cb489795-f878-4936-89ef-79d33f39bdda" key_ModelReferenceID="" referenceID="9c620758-f7dd-43ee-8b13-56ca748362d5" />
                    </ParameterDependencyCondition>
                    <ParameterDependencyTerm referenceID="f44993ab-f025-44bf-87f6-3663a04a0616">
                        <ParameterDependencyTermValue key_ParameterReferenceID="056e481e-4489-4be4-b4aa-7893fe57d6a0" key_ParameterValueReferenceID="f9e873a9-8589-4b95-b6b7-56ed2048d27f" key_ModelReferenceID="" referenceID="abe19fd0-79f6-4461-9111-a458fb240371" />
                    </ParameterDependencyTerm>
                </ParameterDependencyElement>
            </ParameterDependencyGroup>
            <ParameterDependencyGroup key_Name="DependencyGroup# 1" label="DependencyGroup# 1" comment="" include="true" referenceID="0f3239c8-45d0-489a-b664-ab9771fb8fb4">
                <ParameterDependencyElement criteria="0" referenceID="69cebfb0-dbf3-43f6-8da7-a7eb16e5e246">
                    <ParameterDependencyCondition referenceID="287a2038-95b2-4f99-b3d0-9bfe2bdc01e5">
                        <ParameterDependencyConditionValue key_ParameterReferenceID="efeaef6f-c46f-4a75-a08c-992421000b2f" key_ParameterValueReferenceID="af5edc86-c480-4a45-b351-7c0a5f65532d" key_ModelReferenceID="" referenceID="f4739c57-b119-4d10-9692-6ee417988134" />
                    </ParameterDependencyCondition>
                    <ParameterDependencyTerm referenceID="583a8329-f252-4e37-89e2-734bba0cb1dd">
                        <ParameterDependencyTermValue key_ParameterReferenceID="8b03e11c-18e4-4019-a105-4e4ffd863f7d" key_ParameterValueReferenceID="69a9232d-65c3-4482-9a62-a6463bcdec6f" key_ModelReferenceID="" referenceID="b95e5c62-1fda-46bb-9b5f-79dea5f29054" />
                    </ParameterDependencyTerm>
                </ParameterDependencyElement>
                <ParameterDependencyElement criteria="0" referenceID="ac60f375-aae8-4b5e-bafe-0f4976b207b3">
                    <ParameterDependencyCondition referenceID="beae54f2-abac-4d84-b69d-fb26cd61f380">
                        <ParameterDependencyConditionValue key_ParameterReferenceID="efeaef6f-c46f-4a75-a08c-992421000b2f" key_ParameterValueReferenceID="af5edc86-c480-4a45-b351-7c0a5f65532d" key_ModelReferenceID="" referenceID="f4739c57-b119-4d10-9692-6ee417988134" />
                    </ParameterDependencyCondition>
                    <ParameterDependencyTerm referenceID="1ab91962-2403-4add-b193-e6e209bbeea9">
                        <ParameterDependencyTermValue key_ParameterReferenceID="8b03e11c-18e4-4019-a105-4e4ffd863f7d" key_ParameterValueReferenceID="bb93a369-32e4-4630-bcaa-a89626ab9964" key_ModelReferenceID="" referenceID="145f0f8e-349b-4b3b-9eb7-d57f209bfe37" />
                    </ParameterDependencyTerm>
                </ParameterDependencyElement>
                <ParameterDependencyElement criteria="0" referenceID="0c1362eb-f059-42f9-8095-df2d3824a18f">
                    <ParameterDependencyCondition referenceID="c86f3ae4-9314-4a9b-a8fa-5dc1308a83e8">
                        <ParameterDependencyConditionValue key_ParameterReferenceID="efeaef6f-c46f-4a75-a08c-992421000b2f" key_ParameterValueReferenceID="af5edc86-c480-4a45-b351-7c0a5f65532d" key_ModelReferenceID="" referenceID="f4739c57-b119-4d10-9692-6ee417988134" />
                    </ParameterDependencyCondition>
                    <ParameterDependencyTerm referenceID="940c727a-b456-4030-83a9-d650a48271d2">
                        <ParameterDependencyTermValue key_ParameterReferenceID="8b03e11c-18e4-4019-a105-4e4ffd863f7d" key_ParameterValueReferenceID="d8a09087-71cf-47d6-8d45-5ba49758ce12" key_ModelReferenceID="" referenceID="f094e7c1-5e2e-42ca-a566-c9bf2174fd36" />
                    </ParameterDependencyTerm>
                </ParameterDependencyElement>
                <ParameterDependencyElement criteria="0" referenceID="30774908-080e-46e3-942f-ddf56d757c84">
                    <ParameterDependencyCondition referenceID="5f4cb4ed-04c0-4724-b6e5-abbcfb1ba515">
                        <ParameterDependencyConditionValue key_ParameterReferenceID="efeaef6f-c46f-4a75-a08c-992421000b2f" key_ParameterValueReferenceID="af5edc86-c480-4a45-b351-7c0a5f65532d" key_ModelReferenceID="" referenceID="f4739c57-b119-4d10-9692-6ee417988134" />
                    </ParameterDependencyCondition>
                    <ParameterDependencyTerm referenceID="3edcacfc-8b20-4372-af3d-344c92e2f8f9">
                        <ParameterDependencyTermValue key_ParameterReferenceID="8b03e11c-18e4-4019-a105-4e4ffd863f7d" key_ParameterValueReferenceID="3094f970-0009-4f37-b41e-5341a3760c64" key_ModelReferenceID="" referenceID="7fb0c24d-8165-4f31-99ad-ac57b19868f6" />
                    </ParameterDependencyTerm>
                </ParameterDependencyElement>
                <ParameterDependencyElement criteria="0" referenceID="b65817e3-81ea-4a87-a95d-6b67daa6612a">
                    <ParameterDependencyCondition referenceID="ec02834a-6cdc-46a6-a71f-87f070f9af01">
                        <ParameterDependencyConditionValue key_ParameterReferenceID="efeaef6f-c46f-4a75-a08c-992421000b2f" key_ParameterValueReferenceID="989a486c-e76d-4e39-aa06-f76d11aaaa4f" key_ModelReferenceID="" referenceID="641248b1-5a14-4720-a3e3-a8880fbfc9c2" />
                    </ParameterDependencyCondition>
                    <ParameterDependencyTerm referenceID="a0e85abd-524f-46ea-912d-6b7f56c5a433">
                        <ParameterDependencyTermValue key_ParameterReferenceID="8b03e11c-18e4-4019-a105-4e4ffd863f7d" key_ParameterValueReferenceID="69a9232d-65c3-4482-9a62-a6463bcdec6f" key_ModelReferenceID="" referenceID="ea152c85-dc04-43fa-ba00-84f0151003d8" />
                    </ParameterDependencyTerm>
                </ParameterDependencyElement>
                <ParameterDependencyElement criteria="0" referenceID="35132f0c-17ed-4a3e-91d6-f53af169b980">
                    <ParameterDependencyCondition referenceID="4f4d6f3d-8a85-4c18-ba4f-9af8401512cf">
                        <ParameterDependencyConditionValue key_ParameterReferenceID="efeaef6f-c46f-4a75-a08c-992421000b2f" key_ParameterValueReferenceID="989a486c-e76d-4e39-aa06-f76d11aaaa4f" key_ModelReferenceID="" referenceID="641248b1-5a14-4720-a3e3-a8880fbfc9c2" />
                    </ParameterDependencyCondition>
                    <ParameterDependencyTerm referenceID="62850f63-ac8b-4a34-8962-fd52e8864014">
                        <ParameterDependencyTermValue key_ParameterReferenceID="8b03e11c-18e4-4019-a105-4e4ffd863f7d" key_ParameterValueReferenceID="bb93a369-32e4-4630-bcaa-a89626ab9964" key_ModelReferenceID="" referenceID="5d0afa59-2b7b-404e-8950-97b978d89bad" />
                    </ParameterDependencyTerm>
                </ParameterDependencyElement>
                <ParameterDependencyElement criteria="0" referenceID="78070a9c-ab27-4eea-a6a3-e7a831278bc0">
                    <ParameterDependencyCondition referenceID="385c4e2c-2ade-4ace-968f-9630033b54e7">
                        <ParameterDependencyConditionValue key_ParameterReferenceID="efeaef6f-c46f-4a75-a08c-992421000b2f" key_ParameterValueReferenceID="989a486c-e76d-4e39-aa06-f76d11aaaa4f" key_ModelReferenceID="" referenceID="641248b1-5a14-4720-a3e3-a8880fbfc9c2" />
                    </ParameterDependencyCondition>
                    <ParameterDependencyTerm referenceID="6755f18e-ac01-4a59-ab3d-ef72668c21ab">
                        <ParameterDependencyTermValue key_ParameterReferenceID="8b03e11c-18e4-4019-a105-4e4ffd863f7d" key_ParameterValueReferenceID="d8a09087-71cf-47d6-8d45-5ba49758ce12" key_ModelReferenceID="" referenceID="e6f74096-536d-43b0-907a-20fee8680c3d" />
                    </ParameterDependencyTerm>
                </ParameterDependencyElement>
                <ParameterDependencyElement criteria="0" referenceID="56d858e3-9e3b-4b28-bf02-7840d6d2866f">
                    <ParameterDependencyCondition referenceID="13b3f455-1a77-4714-891c-6e98e9ee638d">
                        <ParameterDependencyConditionValue key_ParameterReferenceID="efeaef6f-c46f-4a75-a08c-992421000b2f" key_ParameterValueReferenceID="989a486c-e76d-4e39-aa06-f76d11aaaa4f" key_ModelReferenceID="" referenceID="641248b1-5a14-4720-a3e3-a8880fbfc9c2" />
                    </ParameterDependencyCondition>
                    <ParameterDependencyTerm referenceID="ed98fdca-77be-4465-a42a-599df0c8b491">
                        <ParameterDependencyTermValue key_ParameterReferenceID="8b03e11c-18e4-4019-a105-4e4ffd863f7d" key_ParameterValueReferenceID="3094f970-0009-4f37-b41e-5341a3760c64" key_ModelReferenceID="" referenceID="97974bd0-a114-403d-9329-a3209c2000cb" />
                    </ParameterDependencyTerm>
                </ParameterDependencyElement>
                <ParameterDependencyElement criteria="0" referenceID="6b5e550d-be14-4ad4-97c6-181374a219ba">
                    <ParameterDependencyCondition referenceID="ff2d08e5-ecb0-4562-80c9-57d73796a317">
                        <ParameterDependencyConditionValue key_ParameterReferenceID="efeaef6f-c46f-4a75-a08c-992421000b2f" key_ParameterValueReferenceID="989a486c-e76d-4e39-aa06-f76d11aaaa4f" key_ModelReferenceID="" referenceID="641248b1-5a14-4720-a3e3-a8880fbfc9c2" />
                    </ParameterDependencyCondition>
                    <ParameterDependencyTerm referenceID="2f11b51f-8998-4ba0-83cb-f2abc64eadf4">
                        <ParameterDependencyTermValue key_ParameterReferenceID="8b03e11c-18e4-4019-a105-4e4ffd863f7d" key_ParameterValueReferenceID="159f263a-3983-4f67-8be8-51d8580a14c4" key_ModelReferenceID="" referenceID="857efa36-1617-44f3-bf49-df28fbb41288" />
                    </ParameterDependencyTerm>
                </ParameterDependencyElement>
                <ParameterDependencyElement criteria="0" referenceID="68e2a541-2e7b-4d8c-9ba0-bf81aca2f492">
                    <ParameterDependencyCondition referenceID="75d5fd7d-0c53-4ab7-a515-fbd4b824be80">
                        <ParameterDependencyConditionValue key_ParameterReferenceID="efeaef6f-c46f-4a75-a08c-992421000b2f" key_ParameterValueReferenceID="af5edc86-c480-4a45-b351-7c0a5f65532d" key_ModelReferenceID="" referenceID="f4739c57-b119-4d10-9692-6ee417988134" />
                    </ParameterDependencyCondition>
                    <ParameterDependencyTerm referenceID="644ef8df-92e3-48d0-931b-1605a4f19b2c">
                        <ParameterDependencyTermValue key_ParameterReferenceID="8b03e11c-18e4-4019-a105-4e4ffd863f7d" key_ParameterValueReferenceID="159f263a-3983-4f67-8be8-51d8580a14c4" key_ModelReferenceID="" referenceID="20377187-f99e-4d7b-ab21-349455871066" />
                    </ParameterDependencyTerm>
                </ParameterDependencyElement>
            </ParameterDependencyGroup>
        </ParameterCombinationRules>
    </ModelParameters>
    <Actions referenceID="95bafd1b-a7e0-426c-9ac6-1e493369b420">
        <Action key_Name="FromThread" label="FromThread" comment="" weight="1" disabled="false" defaultClusterReferenceID="" uiPersistentID="" uiPattern="" uiMethod="" automated="false" referenceID="b8b794d9-c257-49a0-8563-2c382351c539">
            <ActionParameters referenceID="d42b7916-67ad-4f1a-937b-3eac8b63d779">
                <ActionParameter key_ActionParameterReferenceID="efeaef6f-c46f-4a75-a08c-992421000b2f" referenceID="04233735-a229-4b3e-9d7b-18bce98a3e02" />
                <ActionParameter key_ActionParameterReferenceID="8b03e11c-18e4-4019-a105-4e4ffd863f7d" referenceID="a146796f-bb83-44e9-9b04-6c29a8e902fe" />
                <ActionParameter key_ActionParameterReferenceID="056e481e-4489-4be4-b4aa-7893fe57d6a0" referenceID="68b0a94f-3d46-426b-90ad-e6e3b10e74fd" />
                <ActionParameter key_ActionParameterReferenceID="b5baa399-a936-41a9-be76-dc6e0f54bd4c" referenceID="01a7df15-8c67-4202-a31f-3dc0706647e0" />
                <ActionParameter key_ActionParameterReferenceID="8b101b5e-20c6-4ee6-b717-261ef7063ea0" referenceID="b02233f6-38fe-4500-b7c0-7ae53aa09430" />
            </ActionParameters>
        </Action>
    </Actions>
    <TransitionRules referenceID="60e2535b-9fc3-46a9-891f-f1178f119446">
    </TransitionRules>
    <EntryPoints seed="1" referenceID="27cd638c-b405-4f74-bb92-a92621ed5eee" />
    <AssertionRules referenceID="42777240-4b55-47be-b43c-9581504aaf4a" />
    <ModelInfo overview="" constructionInfo="" referenceID="89d8b312-8a7f-4d43-967d-c3828fb12f2c" />
    <ModelReferences referenceID="3640ff86-cf36-47bb-b6c6-948c1884af62" />
    <ModelLinkRules referenceID="f8e7035e-f09d-4dd1-9f85-9f7f73d16a1c" />
    <TestQueries referenceID="566dbe74-55ac-4e96-a109-5131e352dd30">
        <TestQuery key_Name="DispatcherOwnershipModel" label="DispatcherOwnershipModel" testOutputFilePathName="&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-16&quot;?&gt;&#xD;&#xA;&lt;StandAloneLocation xmlns:xsd=&quot;http://www.w3.org/2001/XMLSchema&quot; xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot;&gt;&#xD;&#xA;  &lt;TestCaseFileName&gt;E:\Documents and Settings\Microsoft\My Documents\DispatcherOwnershipModel.xtc&lt;/TestCaseFileName&gt;&#xD;&#xA;&lt;/StandAloneLocation&gt;" comment="" isStateless="true" referenceID="316dff44-b678-4065-b56d-90e09758a11d" maxTestCases="0" applyFilters="true" testOutputLocationType="Microsoft.Ite.StandAloneInterface.StandAloneLocation,Microsoft.Ite.StandAloneTcmInterface, Version=2.1.2005.0, Culture=neutral, PublicKeyToken=null~" externalDataXml="" externalDataType="" disabled="false">
            <TestPattern seed="1" referenceID="12571387-66a4-471b-8215-ec59750a679b">
                <TestPatternElement testPatternElementType="0" modelReferenceID="869cf956-6c1c-42f0-8fa6-fe7c81f6678f" referenceID="f8ee9180-fe1d-4cde-aedc-cce65545242e">
                    <ActionTestPatternElement actionReferenceID="b8b794d9-c257-49a0-8563-2c382351c539" referenceID="69c39595-1aa4-4a7a-a932-6b4410f97ad9">
                        <ParameterTestPatternElement key_ParameterReferenceID="efeaef6f-c46f-4a75-a08c-992421000b2f" parameterValueReferenceID="" lowWeight="0" highWeight="0" validFilter="0" automatedFilter="0" bucketFilter="" referenceID="768a0b55-51b6-458b-9873-290728b6d843" />
                        <ParameterTestPatternElement key_ParameterReferenceID="8b03e11c-18e4-4019-a105-4e4ffd863f7d" parameterValueReferenceID="" lowWeight="0" highWeight="0" validFilter="0" automatedFilter="0" bucketFilter="" referenceID="691591bc-9611-48a2-8b49-2024830720c7" />
                        <ParameterTestPatternElement key_ParameterReferenceID="056e481e-4489-4be4-b4aa-7893fe57d6a0" parameterValueReferenceID="" lowWeight="0" highWeight="0" validFilter="0" automatedFilter="0" bucketFilter="" referenceID="758832df-c363-4b2f-b37e-b76e5806ca59" />
                        <ParameterTestPatternElement key_ParameterReferenceID="b5baa399-a936-41a9-be76-dc6e0f54bd4c" parameterValueReferenceID="" lowWeight="0" highWeight="0" validFilter="0" automatedFilter="0" bucketFilter="" referenceID="a9daf98c-9b42-4bfe-a42e-97cfae5f08f2" />
                        <ParameterTestPatternElement key_ParameterReferenceID="8b101b5e-20c6-4ee6-b717-261ef7063ea0" parameterValueReferenceID="" lowWeight="0" highWeight="0" validFilter="0" automatedFilter="0" bucketFilter="" referenceID="320107f2-c6dd-4724-9963-967efe7556fc" />
                    </ActionTestPatternElement>
                </TestPatternElement>
            </TestPattern>
        </TestQuery>
    </TestQueries>
    <TestFilters referenceID="8e54048c-7b0f-4109-a961-f79f0bdc8342" />
    <CustomData referenceID="e648dd0b-d4a3-488f-9c8e-7d2a45e2359c" />
</IteModel>